using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCreate : MonoBehaviour
{
    private GameObject[] cubes = new GameObject[10];

    public float timer, interval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(-5, 0, 0);
        for (int i = 0; i < 10; i++)
        {
            cubes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubes[i].transform.position = pos;
            cubes[i].name = "Cube_" + i;
            pos.x++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            for (int i = 0; i < 10; i++)
            {
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    cubes[i].SetActive(false);
                }
                else cubes[i].SetActive(true);
            }

            timer = 0;
        }

    }
}
