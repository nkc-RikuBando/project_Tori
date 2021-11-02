using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandActiveChanger : MonoBehaviour
{
    [SerializeField] private float findDistance;

    [SerializeField] private GameObject player;
    [SerializeField] private List<GameObject> stageList=new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            stageList.Add(transform.GetChild(i).gameObject);
        }

        StartCoroutine(DistanceCheck());
    }

    IEnumerator DistanceCheck()
    {
        while (true)
        {
            for(int i=0;i<stageList.Count;++i)
            {
                float distance = (player.transform.position - stageList[i].transform.position).magnitude;
                if(Mathf.Abs(distance)<Mathf.Abs(findDistance))
                {
                    stageList[i].SetActive(true);
                }
                else
                {
                    stageList[i].SetActive(false);
                }

                Debug.Log(i + " ‚Ì‹——£ " + distance);
            }

            yield return new WaitForSeconds(3f);
        }
    }

}
