using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ReparentWindow : EditorWindow
{

    [MenuItem("Tools/Reparenter")]    
    public static void ShowWindow()
    {
        //Get existing open window or if none, make a new one:
        ReparentWindow window = (ReparentWindow)EditorWindow.GetWindow(typeof(ReparentWindow));
        window.Show();
    }

    /// <summary>
    /// Creates the editor GUI.
    /// </summary>
    private void OnGUI()
    {
        Transform[] m_children = Selection.transforms;
        // The actual window code goes here
        if (GUILayout.Button("Parent objects"))
        {


            Reparent(m_children);
        }

        if (GUILayout.Button("DeParent objects"))
        {
            DeParent(m_children);
        }
    }

    private void Reparent(Transform[] m_children)
    {
        GameObject _newObject = new GameObject();

        _newObject.name = "//TODO Change Name";
        foreach (var item in m_children)
        {
            item.parent = _newObject.transform;
        }
    }

    private void DeParent(Transform[] m_children)
    {
        foreach (var item in m_children)
        {
            item.SetParent(null);
        }
    }
}
