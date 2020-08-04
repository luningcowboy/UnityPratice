using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CheckMouse()
    {
        var isButtonDown = false;
        isButtonDown = Input.GetMouseButtonDown(0); // left
        isButtonDown = Input.GetMouseButtonDown(1); // right
        isButtonDown = Input.GetMouseButtonDown(2); // center
        var isButtonUp = false;
        isButtonUp = Input.GetMouseButtonUp(0);
        isButtonUp = Input.GetMouseButtonUp(1);
        isButtonUp = Input.GetMouseButtonUp(2);
        // 获取鼠标移动距离
        float value;
        value = Input.GetAxis("Mouse X");
        value = Input.GetAxis("Mouse Y");
    }
    private void CheckKeyboard()
    {
        var hVal = Input.GetAxis("Horizontal");
        var vVal = Input.GetAxis("Vertical");
        if(hVal != 0)
        {
            print("Horizontal movement selected:" + hVal);
        }
        if(vVal != 0)
        {
            print("Vertical movement selected:" + vVal);
        }
        var isKeyDown = Input.GetKey(KeyCode.K);
        if(isKeyDown)
        {
            print("K is down");
        }
        if(Input.GetKey(KeyCode.A)){
            print("The 'A' key is press down.");
        }
        if(Input.GetKeyDown(KeyCode.B)){
            print("THe 'B' key is pressed");
        }
        if(Input.GetKeyUp(KeyCode.C)){
            print("The 'C' key is pressed");
        }

    }
}
