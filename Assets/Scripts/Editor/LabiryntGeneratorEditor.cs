using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LabiryntGenerator))]
public class LabiryntGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Generuj"))
        { 
            (target as LabiryntGenerator).Generate();
        }

        if (GUILayout.Button("Wyczyœæ"))
        {
            (target as LabiryntGenerator).Clean();
        }
    }
}
