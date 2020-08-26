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
    [CustomValueDrawer("MyStaticCustomDrawerInstance")]
    public float CustomDrawerInstance;

    private float MyStaticCustomDrawerInstance(float value, GUIContent label)
    {
        return EditorGUILayout.Slider(label, value, this.Min, this.Max);
    }

    [CustomValueDrawer("MyStaticCustomDrawerStatic")]
    public float CustomDrawerStatic;

    private static float MyStaticCustomDrawerStatic(float value, GUIContent label)
    {
        return EditorGUILayout.Slider(label, value, 0f, 10f);
    }
    [CustomValueDrawer("HaveLabelNameFunction")]
    public string HaveLableName;

    [CustomValueDrawer("NoLabelNameFunction")]
    public string NoLableName;

    public float Max = 100, Min = 0;
   
    public string HaveLabelNameFunction(string tmpName, GUIContent label)
    {
        return EditorGUILayout.TextField(label,tmpName);
    }

    public string NoLabelNameFunction(string tmpName, GUIContent label)
    {
        return EditorGUILayout.TextField(label, tmpName);
    }

    [CustomValueDrawer("MyStaticCustomDrawerArray")]
    public float[] CustomDrawerArr = new float[] { 3f, 5f, 6f};

    private float MyStaticCustomDrawerArray(float value, GUIContent label)
    {
        return EditorGUILayout.Slider(value, this.Min, this.Max);
    }
}
