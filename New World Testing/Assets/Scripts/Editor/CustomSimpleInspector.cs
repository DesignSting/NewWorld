using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Simple))]
public class CustomSimpleInspector : Editor
{
    public override void OnInspectorGUI()
    {
        Simple S = target as Simple;
        

        if(GUILayout.Button("Drawer"))
        {
            S.DropdownButton = !S.DropdownButton;
        }

        if(S.DropdownButton == true)
        {
            S.userName = EditorGUILayout.TextField(S.userName);
            S.randomColor = EditorGUILayout.ColorField(S.randomColor);
            S.number = EditorGUILayout.IntSlider(S.number, 0, 52);
        }
    }

}
