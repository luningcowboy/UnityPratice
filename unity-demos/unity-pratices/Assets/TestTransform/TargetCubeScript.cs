using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCubeScript : MonoBehaviour
{
    private GameObject CubeObj;


    // Start is called before the first frame update
    void Start()
    {
        CubeObj = GameObject.Find("Cube");
    }

    // Update is called once per frame
    void Update()
    {
        CubeObj.transform.Translate(.1f, 0f, 0f);
        CubeObj.transform.Rotate(0f, 0f , 1f);
        CubeObj.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
}
