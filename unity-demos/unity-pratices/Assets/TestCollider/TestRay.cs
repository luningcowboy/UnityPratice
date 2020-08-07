using System;
using UnityEngine;

public class TestRay: MonoBehaviour
{
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, 1000))
        {
            print("there is something in front of the camera");
        }
    }
}