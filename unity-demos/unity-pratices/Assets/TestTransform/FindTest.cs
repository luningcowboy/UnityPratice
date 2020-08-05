using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTest : MonoBehaviour
{
    public GameObject objectYouWant;
    // Start is called before the first frame update
    void Start()
    {
        TestFindByName();
        TestFindByTag();
    }
    private void TestFindByName()
    {
        var objCube = GameObject.Find("Cube");
        if(objCube != null)
        {
            print("find cube game object success");
        }
        else
        {
            print("find cube game object failed");
        }

    }
    private void TestFindByTag()
    {
        var objCube = GameObject.FindWithTag("TagCube");
        if(objCube != null)
        {
            print("find cube game object success");
        }
        else
        {
            print("find cube game object failed");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
