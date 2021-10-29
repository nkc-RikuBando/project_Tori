using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextChange : MonoBehaviour
{
    

    [SerializeField] Text text_RingName;
    [SerializeField] Text text_RingNum;
    [SerializeField] Text text_RingSum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextChange_Num(int textChange_RingNum)
    {
        text_RingNum.text =textChange_RingNum.ToString();
    }

    public void TextChange_Sum(int textChange_RingSum)
    {
        text_RingSum.text = "/ " + textChange_RingSum.ToString();
    }

    public void TextChange_Name(string textChange_RingName)
    {
        text_RingName.text = textChange_RingName;
        Debug.Log(textChange_RingName);
        //text_RingName.GetComponent<CanvasGroup>().alpha = 0;
        //NameFade();
    }

    IEnumerator NameFade()
    {
        int fadeInCount = 10;
        int fadeOutCount = 20;

        while (fadeInCount > 0)
        {
            text_RingName.GetComponent<CanvasGroup>().alpha += 0.1f;
            fadeInCount--;
        }

        yield return new WaitForSeconds(1f);

        while(fadeOutCount > 0)
        {
            text_RingName.GetComponent<CanvasGroup>().alpha -= 0.1f;
            fadeOutCount--;
        }
    }

}

