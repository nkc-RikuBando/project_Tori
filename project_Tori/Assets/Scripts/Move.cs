using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 vec;
    private float inputH;
    //private float inputV;

    Vector3 posUp;
    Vector3 posDown;

    void Start()
    {
        
    }

    void Update()
    {
        //inputV = Input.GetAxisRaw("Vertical");
        //vec = new Vector3(0, 0, inputV);
        //transform.position += vec * 5f;

        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, 1f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -1f);
        }

        //if (Input.GetKey(KeyCode.RightArrow)) transform.Rotate(0, 3, 0);
        //else if (Input.GetKey(KeyCode.LeftArrow)) transform.Rotate(0, -3, 0);
        inputH = Input.GetAxisRaw("Horizontal");
        float angle = inputH * 3.0f;
        transform.Rotate(Vector3.up, angle);

        if (Input.GetKey(KeyCode.RightShift))
        {
            transform.Rotate(5, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(-5, 0, 0);
        }


        if (Input.GetKey(KeyCode.W)) transform.position += new Vector3(0, 3, 0);
        else if (Input.GetKey(KeyCode.S)) transform.position += new Vector3(0, -3, 0);
    }
}
