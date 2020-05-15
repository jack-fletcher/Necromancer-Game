using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TimeSwitcher : MonoBehaviour, IObserver
{
    /// <summary>
    /// 
    /// </summary>
    public TimeManager _time;
    /// <summary>
    /// 
    /// </summary>
    public Material m_nightSkybox;
    /// <summary>
    /// 
    /// </summary>
    public Material m_daySkybox;

    /// <summary>
    /// 
    /// </summary>
    private GameObject[] m_dayLights;
    /// <summary>
    /// 
    /// </summary>
    private GameObject[] m_nightLights;
    private void OnEnable()
    {


        _time.Subscribe(this);


        m_dayLights = GameObject.FindGameObjectsWithTag("DayLighting");
        m_nightLights = GameObject.FindGameObjectsWithTag("NightLighting");
    }

    public void UpdateState(ISubject _subject)
    {
        if (_subject is TimeManager _time)
        {
            ChangeLighting();
        }
    }

    private void ChangeLighting()
    {



       
        ///If its not nighttime, change skybox to this and set the default skybox
        ///Additionally, turn on situational lighting
        switch (_time.TimeOfDay)
        {
            case TimeOfDay.day:
                RenderSettings.skybox = m_daySkybox;

                for (int i = 0; i < m_dayLights.Length; i++)
                {
                    m_dayLights[i].GetComponent<Light>().enabled = true;
                }
                for (int i = 0; i < m_nightLights.Length; i++)
                {
                    m_nightLights[i].GetComponent<Light>().enabled = false;
                }
                break;

            case TimeOfDay.night:
                RenderSettings.skybox = m_nightSkybox;
                for (int i = 0; i < m_dayLights.Length; i++)
                {
                    m_dayLights[i].GetComponent<Light>().enabled = false;
                }
                for (int i = 0; i < m_nightLights.Length; i++)
                {
                    m_nightLights[i].GetComponent<Light>().enabled = true;
                }
                break;

            default:

                Debug.LogError("Case not yet implemented");
                break;
        }
       
    }

}

