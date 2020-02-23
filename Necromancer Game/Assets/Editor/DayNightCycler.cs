using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DayNightCycler : EditorWindow
{

     public Material m_nightSkybox;
    private Material m_defaultSkybox;
    [MenuItem("DevTools/Cycler")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        DayNightCycler window = (DayNightCycler)EditorWindow.GetWindow(typeof(DayNightCycler));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Night Skybox");
        m_nightSkybox = (Material)EditorGUILayout.ObjectField(m_nightSkybox, typeof(Material), true);
        if (GUILayout.Button("Swap"))
        {
            Swap();
        }
    }

    /// <summary>
    /// Swaps the skybox and enables/disables gameobjects based on this
    /// </summary>
    private void Swap()
    {
        GameObject[] m_globalLight;

        m_globalLight = GameObject.FindGameObjectsWithTag("GlobalLighting");
        ///If its not nighttime, change skybox to this and set the default skybox
        if (RenderSettings.skybox.name != m_nightSkybox.name)
        {
            m_defaultSkybox = RenderSettings.skybox;
            RenderSettings.skybox = m_nightSkybox;

            for (int i = 0; i < m_globalLight.Length; i++)
            {
                m_globalLight[i].SetActive(false);
            }
        }
        ///If they are the same, it must be night time
        else if(RenderSettings.skybox.name == m_nightSkybox.name)
        {
            RenderSettings.skybox = m_defaultSkybox;

            for (int i = 0; i < m_globalLight.Length; i++)
            {
                m_globalLight[i].SetActive(true);
            }
        }
        ///Else give an error message
        else
        {
            Debug.LogError("ERROR: Skybox is not set to either night or day skybox.");
        }
    }


}
