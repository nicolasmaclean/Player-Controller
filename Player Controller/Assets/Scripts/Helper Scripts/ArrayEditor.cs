using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor (typeof (Array))]
public class ArrayEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Array array = (Array)target;
		
		DrawDefaultInspector();

        if(GUILayout.Button ("Apply")) {
			foreach(GameObject go in array.arrayItems) {
                go.transform.parent = array.transform.parent;
            }
            DestroyImmediate(array);
		}

        if(GUILayout.Button("Refresh")) {
            array.updateItems();
        }

        if(GUILayout.Button("Delete")) {
            foreach(GameObject go in array.arrayItems) {
                DestroyImmediate(go);
            }
        }
    }
}
