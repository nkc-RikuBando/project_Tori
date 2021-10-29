using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputer;
using Bridge;


public class PlayerContoller : MonoBehaviour
{
    private IInputerKeyBorad inputerKeyBorad;
    Vector3 inputDir = Vector3.zero;

    float speed = 7f;

    // Start is called before the first frame update
    void Start()
    {
        inputerKeyBorad = GetComponent<IInputerKeyBorad>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveX();
        MoveZ();
        MoveUp();
        MoveDown();
    }

    private void MoveX()
    {
        transform.Translate(inputerKeyBorad.MoveH() * speed * Time.deltaTime, 0f, 0f);
    }

    private void MoveZ()
    {
        transform.Translate(0f, 0f, inputerKeyBorad.MoveV() * speed * Time.deltaTime);
    }

    private void MoveUp()
    {
        if (inputerKeyBorad.MoveUp()) return;
        transform.Translate(0f, 0.1f, 0f);
    }

    private void MoveDown()
    {
        if (inputerKeyBorad.MoveDown()) return;
        transform.Translate(0f, -0.1f, 0f);
    }

}
