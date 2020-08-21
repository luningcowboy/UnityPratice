using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonoBehaviour : MonoBehaviour
{
    private void Awake()
    {
        print("Awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        print("Start");
        
    }

    // Update is called once per frame
    void Update()
    {
        print("Update");
    }

    private void FixedUpdate()
    {
        print("FixedUpdate");
        
    }

    private void LateUpdate()
    {
        print("LateUpdate");
        
    }

    private void OnGUI()
    {
        print("OnGUI");
        
    }

    private void OnDestroy()
    {
        print("OnDestory");
        
    }

    private void OnEnable()
    {
        print("OnEnable");
        
    }
}
