using UnityEngine;
using UnityEditor;

public class HelloWorldWindow : EditorWindow
{
    string v = "";
    string[] messageTypes = new string[] { "Log", "Warning", "Error" };
    int typeOfMessage = 0;

    [MenuItem("Window/Hello World")]
    public static void ShowWindow()
    {
        GetWindow<HelloWorldWindow>("Hello World");
    }

    private void OnGUI()
    {
        GUILayout.Label("Hellow World!", EditorStyles.boldLabel);

        GUILayout.Space(25f);

        GUILayout.Label("Send Message", EditorStyles.boldLabel);
        typeOfMessage = EditorGUILayout.Popup(typeOfMessage, messageTypes);

        GUILayout.BeginHorizontal("Test", GUIStyle.none);

        v = GUILayout.TextField(v);
        if (GUILayout.Button("Print"))
        {
            switch (typeOfMessage)
            {
                case 0:
                    Debug.Log(v);
                    break;
                case 1:
                    Debug.LogWarning(v);
                    break;
                case 2:
                    Debug.LogError(v);
                    break;
                default:
                    Debug.Log(v);
                    break;
            }
        }

        GUILayout.EndHorizontal();

        GUILayout.Space(25f);

        if (GUILayout.Button("Close"))
        {
            this.Close();
        }
    }
}
