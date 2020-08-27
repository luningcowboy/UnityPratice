using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ImageTestRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.forward * 120 * Time.deltaTime);
        
    }
}
