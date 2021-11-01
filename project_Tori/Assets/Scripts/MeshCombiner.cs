using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary>
/// ���b�V������������N���X�ł��B
/// </Summary>
public class MeshCombiner : MonoBehaviour
{
    // �t�B�[���h�p�[�c�̐e�I�u�W�F�N�g��Transform�ł��B
    private Transform fieldParent;

    private void Start()
    {
        fieldParent = gameObject.transform;
        CombineMeshWithMaterial();
    }

    /// <Summary>
    /// �����{�^���������ꂽ���̃��\�b�h�ł��B
    /// </Summary>
    public void OnPressedCombineMaterialButton()
    {
        CombineMeshWithMaterial();
    }

    /// <Summary>
    /// ���b�V���ƃ}�e���A�����������܂��B
    /// </Summary>
    void CombineMeshWithMaterial()
    {
        // �n�`�I�u�W�F�N�g��MeshFilter�ւ̎Q�Ƃ�z��Ƃ��ĕێ����܂��B
        MeshFilter[] meshFilters = fieldParent.GetComponentsInChildren<MeshFilter>();
        MeshRenderer[] meshRenderers = fieldParent.GetComponentsInChildren<MeshRenderer>();

        // MeshFilter��MeshRenderer�̐��������Ă��Ȃ��ꍇ�͏����𔲂��܂��B
        if (meshFilters.Length != meshRenderers.Length)
        {
            return;
        }

        // �q�I�u�W�F�N�g�̃��b�V�����}�e���A�����ƂɃO���[�v�������܂��B
        Dictionary<string, Material> matNameDict = new Dictionary<string, Material>();
        Dictionary<string, List<MeshFilter>> matFilterDict = new Dictionary<string, List<MeshFilter>>();
        for (int i = 0; i < meshFilters.Length; i++)
        {
            Material mat = meshRenderers[i].material;
            string matName = mat.name;

            // �����̃L�[�Ƀ}�e���A�����o�^����Ă��Ȃ��ꍇ��MeshFilter�̃��X�g��ǉ����܂��B
            if (!matFilterDict.ContainsKey(matName))
            {
                List<MeshFilter> filterList = new List<MeshFilter>();
                matFilterDict.Add(matName, filterList);
                matNameDict.Add(matName, mat);
            }

            matFilterDict[matName].Add(meshFilters[i]);
        }

        // �O���[�v���������}�e���A�����ƂɃI�u�W�F�N�g���쐬���A���b�V�����������܂��B
        foreach (KeyValuePair<string, List<MeshFilter>> pair in matFilterDict)
        {
            // �����������b�V����\������Q�[���I�u�W�F�N�g���쐬���܂��B
            GameObject obj = CreateMeshObj(pair.Key);
            obj.transform.SetAsFirstSibling();

            // MeshFilter��MeshRenderer���A�^�b�`���܂��B
            MeshFilter combinedMeshFilter = CheckComponent<MeshFilter>(obj);
            MeshRenderer combinedMeshRenderer = CheckComponent<MeshRenderer>(obj);

            // �������郁�b�V���̔z����쐬���܂��B
            List<MeshFilter> filterList = pair.Value;
            CombineInstance[] combine = new CombineInstance[filterList.Count];

            // �������郁�b�V���̏���CombineInstance�ɒǉ����Ă����܂��B
            for (int i = 0; i < filterList.Count; i++)
            {
                combine[i].mesh = filterList[i].sharedMesh;
                combine[i].transform = filterList[i].transform.localToWorldMatrix;
                filterList[i].gameObject.SetActive(false);
            }

            // �����������b�V�����쐬�����Q�[���I�u�W�F�N�g�ɃZ�b�g���܂��B
            combinedMeshFilter.mesh = new Mesh();
            combinedMeshFilter.mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
            combinedMeshFilter.mesh.CombineMeshes(combine);

            // �����������b�V���Ƀ}�e���A�����Z�b�g���܂��B
            combinedMeshRenderer.material = matNameDict[pair.Key];

            // �����������b�V�����R���C�_�[�ɃZ�b�g���܂��B
            MeshCollider meshCol = CheckComponent<MeshCollider>(obj);
            meshCol.sharedMesh = combinedMeshFilter.mesh;

            // �e�I�u�W�F�N�g��\�����܂��B
            fieldParent.gameObject.SetActive(true);
        }
    }

    /// <Summary>
    /// �����������b�V����\������GameObject���쐬���܂��B
    /// </Summary>
    GameObject CreateMeshObj(string matName)
    {
        GameObject obj = new GameObject();
        obj.name = $"CombinedMesh_{matName}";
        obj.transform.SetParent(fieldParent);
        obj.transform.localPosition = Vector3.zero;
        return obj;
    }

    /// <Summary>
    /// �w�肳�ꂽ�R���|�[�l���g�ւ̎Q�Ƃ��擾���܂��B
    /// �R���|�[�l���g���Ȃ��ꍇ�̓A�^�b�`���܂��B
    /// </Summary>
    T CheckComponent<T>(GameObject obj) where T : Component
    {
        // �^�p�����[�^�Ŏw�肵���R���|�[�l���g�ւ̎Q�Ƃ��擾���܂��B
        var targetComp = obj.GetComponent<T>();
        if (targetComp == null)
        {
            targetComp = obj.AddComponent<T>();
        }
        return targetComp;
    }
}