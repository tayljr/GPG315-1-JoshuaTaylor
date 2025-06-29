using UnityEngine;
using UnityEditor;
using System;

public class ScriptSwapper : EditorWindow
{
    GameObject obj1 = null;
    string obj1Name = "No Object Selected!";
    GameObject obj2 = null;
    string obj2Name = "No Object Selected!";
    MonoBehaviour[] obj1Scripts = null;
    MonoBehaviour[] obj2Scripts = null;

    [MenuItem("Window/ScriptSwapper")]
    public static void ShowWindow()
    {
        GetWindow<ScriptSwapper>("Script Swapper");
    }

    private void OnGUI()
    {
        GUILayout.Label("Object 1", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal(GUIStyle.none);
        GUILayout.Box(obj1Name, GUILayout.Width(200f));
        if (GUILayout.Button("Set Object 1"))
        {
            obj1 = Selection.activeGameObject;
            obj1Name = obj1.name;
            //obj1Scripts = obj1.GetComponents<MonoBehaviour>();
            /*
            //scripts list test
            string scripts = "";
            foreach (MonoBehaviour script in obj1Scripts)
            {
                scripts = scripts + ", " + script.GetType();
            }
            Debug.Log(scripts);
            */
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(25f);

        GUILayout.BeginHorizontal(GUIStyle.none);
        GUILayout.Box(obj2Name, GUILayout.Width(200f));
        if (GUILayout.Button("Set Object 2"))
        {
            obj2 = Selection.activeGameObject;
            obj2Name = obj2.name;
            obj2Scripts = obj2.GetComponents<MonoBehaviour>();
            /*
            //scripts list test
            string scripts = "";
            foreach (MonoBehaviour script in obj2Scripts)
            {
                scripts = scripts + ", " + script.GetType();
            }
            Debug.Log(scripts);
            */
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(25f);

        GUILayout.BeginHorizontal(GUIStyle.none);
        if (GUILayout.Button("Replace Obj 2 with Obj 1"))
        {
            obj1Scripts = obj1.GetComponents<MonoBehaviour>();

            foreach (MonoBehaviour script in obj2.GetComponents<MonoBehaviour>())
            {
                DestroyImmediate(script);
            }
            foreach (MonoBehaviour script in obj1Scripts)
            {
                string scriptString = script.GetType().Name;
                Type t = Type.GetType(scriptString);
                obj2.AddComponent(t);
            }
        }
        if (GUILayout.Button("Replace Obj 1 with Obj 2"))
        {
            obj2Scripts = obj2.GetComponents<MonoBehaviour>();

            foreach (MonoBehaviour script in obj1.GetComponents<MonoBehaviour>())
            {
                DestroyImmediate(script);
            }
            foreach (MonoBehaviour script in obj2Scripts)
            {
                string scriptString = script.GetType().Name;
                Type t = Type.GetType(scriptString);
                obj1.AddComponent(t);
            }
        }
        if (GUILayout.Button("Swap scripts"))
        {
            obj1Scripts = obj1.GetComponents<MonoBehaviour>();
            obj2Scripts = obj2.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in obj1.GetComponents<MonoBehaviour>())
            {
                DestroyImmediate(script);
            }
            foreach (MonoBehaviour script in obj2Scripts)
            {
                string scriptString = script.GetType().Name;
                Type t = Type.GetType(scriptString);
                obj1.AddComponent(t);
            }
            foreach (MonoBehaviour script in obj2.GetComponents<MonoBehaviour>())
            {
                DestroyImmediate(script);
            }
            foreach (MonoBehaviour script in obj1Scripts)
            {
                string scriptString = script.GetType().Name;
                Type t = Type.GetType(scriptString);
                obj2.AddComponent(t);
            }
        }
        GUILayout.EndHorizontal();
    }
}
