using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class TestPropertyOrder : MonoBehaviour
{
    [PropertyOrder(1)]
    public int Second;
    [PropertyOrder(-1)]
    [InfoBox("PropertyOrder")]
    public int First;
}
