using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

public class RuleManager : MonoBehaviour, IGetRingInfo
{
    [SerializeField] GameObject ringObj;
    private List<GameObject> ringList = new List<GameObject>(); //フィールドにあるリングの数がリストに入る

    public int ringSum { get; private set; } //リングの合計
    public int passRingNum { get; private set; }
    private string ringName;
    private Ring ringCs;
    private UIManager uIManager;

    // Start is called before the first frame update
    void Start()
    {
        ringCs = GameObject.Find("RingObj").GetComponent<Ring>();
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        for (int i = 0; i < ringObj.transform.childCount; i++) //リングの親オブジェクトについてる子オブジェクトの数回る
        {
            ringList.Add(ringObj.transform.GetChild(i).gameObject); //子オブジェクトをリストに登録する
        }

        ringSum = ringList.Count; //リストの長さを合計に代入
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
        Debug.Log("くぐった合計は" + passRingNum);
    }

    public string RingNameSet(string ringNameStr)
    {
        uIManager.GetRingName(ringNameStr);
        return ringNameStr;
    }
}
