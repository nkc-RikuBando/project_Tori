using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirShip : MonoBehaviour
{
    [SerializeField] private float angle;
    [SerializeField] private float radius;
    [SerializeField] private GameObject center = null;
    [SerializeField] private float rotateSpeed; // ˆÚ“®‘¬“x
    [SerializeField] private float rotation;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        RotateMove();
        transform.Rotate(new Vector3(0, -rotation, 0));
    }

    static Vector3 RotateAroundY(Vector3 original_position, float angle, float radius)
    {
        Vector3 v = original_position;
        v.z += radius;
        float a = angle * Mathf.Deg2Rad;
        float x = Mathf.Cos(a) * v.x + Mathf.Sin(a) * v.z;
        float y = v.y;
        float z = -Mathf.Sin(a) * v.x + Mathf.Cos(a) * v.z;
        return new Vector3(x, y, z);
    }

    void RotateMove()
    {
        transform.position = RotateAroundY(center.transform.position, angle, radius);
        angle -= rotateSpeed;
    }
}
