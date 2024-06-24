using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WireGenerator)), CanEditMultipleObjects]
public class WireGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        WireGenerator myScript = (WireGenerator)target;
        if (GUILayout.Button("Calculate"))
        {
            myScript.Calculate();
        }
    }
}
