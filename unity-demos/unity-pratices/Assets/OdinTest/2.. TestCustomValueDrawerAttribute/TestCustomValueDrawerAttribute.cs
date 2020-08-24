using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor.Experimental.Networking.PlayerConnection;
using UnityEngine;
using UnityEditor;
using EditorGUILayout = UnityEditor.EditorGUILayout;

public class TestCustomValueDrawerAttribute : MonoBehaviour
{
    [CustomValueDrawer("HaveLabelNameFunction")]
    public string HaveLableName;

    [CustomValueDrawer("NoLabelNameFunction")]
    public string NoLableName;

    public string HaveLabelNameFunction(string tmpName, GUIContent label)
    {
        return EditorGUILayout.TextField(label,tmpName);
    }

    public string NoLabelNameFunction(string tmpName, GUIContent label)
    {
        return EditorGUILayout.TextField(label, tmpName);
    }
}
