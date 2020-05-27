using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour, IObserver
{
    /// <summary>
    /// Reference to the timemanager
    /// </summary>
    [SerializeField] private TimeManager _time = null;
    /// <summary>
    /// The material to set when time of day is daytime
    /// </summary>
    [SerializeField] private Material m_dayMaterial = null;
    /// <summary>
    /// Material to set when time of day is nighttime
    /// </summary>
    [SerializeField] private Material m_nightMaterial = null;
    private Renderer m_rend;
    // Start is called before the first frame update

    /// <summary>
    /// On enable, subscribe to observer
    /// </summary>
    private void OnEnable()
    {
        _time.Subscribe(this);
        m_rend = this.GetComponent<Renderer>();
    }

    /// <summary>
    /// Change the material when the state is changed
    /// </summary>
    /// <param name="_subject"></param>
    void IObserver.UpdateState(ISubject _subject)
    {
        if (_subject is TimeManager _time)
        {
            ChangeMaterial();
        }
    }
    /// <summary>
    /// Change the material of renderer
    /// </summary>
    private void ChangeMaterial()
    {
        switch (_time.TimeOfDay)
        {
            case TimeOfDay.day:
                m_rend.material = m_dayMaterial; break;

            case TimeOfDay.night:
                m_rend.material = m_nightMaterial;

                break;

            default:
                Debug.LogError("Time of day was:" + _time.TimeOfDay);
                break;
        }
    }
}
