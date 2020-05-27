using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DayNightCycler : EditorWindow
{

     [SerializeField] private Material m_nightSkybox;
    [SerializeField] private Material m_defaultSkybox;
    GameObject[] m_dayLights;

    GameObject[] m_nightLights;

    [MenuItem("Tools/Cycler")]
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

        GUILayout.Label("Day Skybox");
        m_defaultSkybox = (Material)EditorGUILayout.ObjectField(m_defaultSkybox, typeof(Material), true);

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
        m_dayLights = GameObject.FindGameObjectsWithTag("DayLighting");
        m_nightLights = GameObject.FindGameObjectsWithTag("NightLighting");
        ///If its not nighttime, change skybox to this and set the default skybox - becomes night time
        if (RenderSettings.skybox.name != m_nightSkybox.name)
        {
            RenderSettings.skybox = m_nightSkybox;

            for (int i = 0; i < m_dayLights.Length; i++)
            {
                m_dayLights[i].GetComponent<Light>().enabled = false;
            }
            for (int i = 0; i < m_nightLights.Length; i++)
            {
                m_nightLights[i].GetComponent<Light>().enabled = true;
            }
        }
        ///If they are the same, it must be night time so set it to day - becomes day time
        else if(RenderSettings.skybox.name == m_nightSkybox.name)
        {
            RenderSettings.skybox = m_defaultSkybox;

            for (int i = 0; i < m_dayLights.Length; i++)
            {
                m_dayLights[i].GetComponent<Light>().enabled = true;
            }
            for (int i = 0; i < m_nightLights.Length; i++)
            {
                m_nightLights[i].GetComponent<Light>().enabled = false;
            }
        }
        ///Else give an error message
        else
        {
            Debug.LogError("ERROR: Skybox is not set to either night or day skybox.");
        }
    }


}
