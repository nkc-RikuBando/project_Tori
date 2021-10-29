using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

public class UIManager : MonoBehaviour,IUIChanger
{
    private int text_RingSum;
    private int text_PassRingNum;
    private string text_RingName;

    private UITextChange uITextChange;

    void Awake()
    {
        uITextChange = GetComponent<UITextChange>();
    }

    void Start()
    {
        
    }

    public void GetPassRingNum(int passRingNum)
    {
        uITextChange.TextChange_Num(passRingNum);
    }

    public void GetRingName(string ringName)
    {
        uITextChange.TextChange_Name(ringName);
    }

    public void GetRingSum(int ringSum)
    {
        uITextChange.TextChange_Sum(ringSum);
    }

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
