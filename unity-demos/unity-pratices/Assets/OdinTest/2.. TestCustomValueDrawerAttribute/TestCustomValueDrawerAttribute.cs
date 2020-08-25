using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor.Experimental.Networking.PlayerConnection;
using UnityEngine;
using UnityEditor;
using EditorGUI = UnityEditor.EditorGUI;
using EditorGUILayout = UnityEditor.EditorGUILayout;

public class TestCustomValueDrawerAttribute : MonoBehaviour
{
    [CustomValueDrawer("HaveLabelNameFunction")]
    public string HaveLableName;

    [CustomValueDrawer("NoLabelNameFunction")]
    public string NoLableName;

    public float Max = 100, Min = 0;
   
    [CustomValueDrawer("MyStaticCustomDrawerStatic")]
    public float CustomDrawerStatic;

    private static float MyStaticCustomDrawerStatic(float value, GUIContent label)
    {
        return EditorGUILayout.Slider(label, value, 0f, 10f);
    }

    public string HaveLabelNameFunction(string tmpName, GUIContent label)
    {
        return EditorGUILayout.TextField(label,tmpName);
    }

    public string NoLabelNameFunction(string tmpName, GUIContent label)
    {
        return EditorGUILayout.TextField(label, tmpName);
    }
}
