using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    Vector3 rotationEuler;
    int _rotationSpeed = 200; //degrees to increment

    void Update()
    {
        rotationEuler += Vector3.forward * _rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotationEuler);
    }
}
