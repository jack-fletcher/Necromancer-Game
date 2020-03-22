using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private GameObject[] m_globalLight;
    private void OnEnable()
    {


        _time.Subscribe(this);


        m_globalLight = GameObject.FindGameObjectsWithTag("GlobalLighting");
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
        switch (_time.TimeOfDay)
        {
            case "day":
                RenderSettings.skybox = m_daySkybox;

                for (int i = 0; i < m_globalLight.Length; i++)
                {
                    m_globalLight[i].SetActive(true);
                }
                break;

            case "night":
                RenderSettings.skybox = m_nightSkybox;
                for (int i = 0; i < m_globalLight.Length; i++)
                {
                    m_globalLight[i].SetActive(false);
                }
                break;

            default:

                Debug.LogError("Case not yet implemented");
                break;
        }
       
    }
}

