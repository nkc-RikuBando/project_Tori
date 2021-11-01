using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

public class RuleManager : MonoBehaviour, IGetRingInfo
{
    [SerializeField] GameObject ringObj;
    private List<GameObject> ringList = new List<GameObject>(); //�t�B�[���h�ɂ��郊���O�̐������X�g�ɓ���

    public int ringSum { get; private set; } //�����O�̍��v
    public int passRingNum { get; private set; }
    private string ringName;
    private Ring ringCs;
    private UIManager uIManager;

    // Start is called before the first frame update
    void Start()
    {
        ringCs = GameObject.Find("RingObj").GetComponent<Ring>();
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        for (int i = 0; i < ringObj.transform.childCount; i++) //�����O�̐e�I�u�W�F�N�g�ɂ��Ă�q�I�u�W�F�N�g�̐����
        {
            ringList.Add(ringObj.transform.GetChild(i).gameObject); //�q�I�u�W�F�N�g�����X�g�ɓo�^����
        }

        ringSum = ringList.Count; //���X�g�̒��������v�ɑ��
        uIManager.GetRingSum(ringSum);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PassRing()
    {
        passRingNum++;
        uIManager.GetPassRingNum(passRingNum);
        Debug.Log("�����������v��" + passRingNum);
    }

    public string RingNameSet(string ringNameStr)
    {
        uIManager.GetRingName(ringNameStr);
        return ringNameStr;
    }
}
