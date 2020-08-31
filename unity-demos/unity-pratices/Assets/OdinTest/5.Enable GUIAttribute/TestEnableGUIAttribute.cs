using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class TestEnableGUIAttribute : MonoBehaviour
{
    [ShowInInspector]
    public int GUIDisableProperty
    {
        get { return 20; }
    }

    [ShowInInspector, EnableGUI]
    public int InGUIEnableProperty
    {
        get { return 10; }
    }
}
