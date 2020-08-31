using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class TestGUIAttribute : MonoBehaviour
{
    [GUIColor(.3f, .8f, 0.8f, 1f)]
    public int ColoredInt1;

    [GUIColor(0.3f, 0.8f, 0.8f, 1f)] 
    public int ColoredInt2;

    [ButtonGroup]
    [GUIColor(0,1,0)]
    private void Apply()
    {
    }

    [ButtonGroup]
    [GUIColor(1,0,0)]
    private void Cancel()
    {
    }

    [GUIColor("GetButtonColor")]
    [Button(ButtonSizes.Gigantic)]
    private static void IAmFabulous()
    {
    }

    private static Color GetButtonColor()
    {
        Sirenix.Utilities.Editor.GUIHelper.RequestRepaint();
        return Color.HSVToRGB(Mathf.Cos((float)UnityEditor.EditorApplication.timeSinceStartup + 1f) *0.225f + -.325f, 1,1);
    }

    [Button(ButtonSizes.Large)]
    [GUIColor("@Color.Lerp(Color.red, Color.green, Mathf.Sin((float)UnityEditor.EditorApplication.timeSinceStartup))")]
    private static void Expressive_One()
    {
    }
    [Button(ButtonSizes.Large)]
    [GUIColor("CustomColor")]
    private static void Expressive_Two()
    {
    }

# if UNITY_EDITOR
    public Color CustomColor()
    {
        return Color.Lerp(Color.red, Color.green, Mathf.Sin((float)UnityEditor.EditorApplication.timeSinceStartup));
    }
# endif
}
