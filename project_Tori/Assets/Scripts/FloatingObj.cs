using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObj : MonoBehaviour
{
    private Vector3 pos = Vector3.up;
    //[SerializeField] private float MaxYPos;

	void Start()
    {
        
    }

    void Update()
    {
        transform.position += pos;
    }

    void FixedUpdate()
    {
        
    }
}
