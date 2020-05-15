using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour, IObserver
{
    [SerializeField] private TimeManager _time = null;

    [SerializeField] private Material m_dayMaterial = null;
    [SerializeField] private Material m_nightMaterial = null;
    private Renderer m_rend;
    // Start is called before the first frame update

    private void OnEnable()
    {
        _time.Subscribe(this);
        m_rend = this.GetComponent<Renderer>();
    }

    void IObserver.UpdateState(ISubject _subject)
    {
        if (_subject is TimeManager _time)
        {
            ChangeMaterial();
        }
    }

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
