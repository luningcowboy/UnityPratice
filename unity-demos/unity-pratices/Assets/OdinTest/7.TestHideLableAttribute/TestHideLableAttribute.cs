using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class TestHideLableAttribute : MonoBehaviour
{
    public string showLabel = "AAABBBCC";
    [HideLabel]
    public string hideLable = "AbcAbc";

    [ShowInInspector]
    public string ShowPropertyLabel { get; set; }
    [HideLabel][ShowInInspector]
    public string HidePropertyLabel { get; set; }
}
