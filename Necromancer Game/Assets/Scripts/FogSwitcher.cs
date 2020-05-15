using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogSwitcher : MonoBehaviour, IObserver
{
    /// <summary>
    /// Reference tothe TimeManager Subject
    /// </summary>
    [SerializeField] private TimeManager _time = null;

    // Start is called before the first frame update

    private void OnEnable()
    {
        _time.Subscribe(this);
    }

    void Start()
    {
        //RenderSettings.fog = false;
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    void IObserver.UpdateState(ISubject _subject)
    {
       if (_subject is TimeManager _time)
        {
            ChangeFog();
        }
    }

    private void ChangeFog()
    {

        switch (_time.TimeOfDay)
        {
            case TimeOfDay.day:
                RenderSettings.fog = false;
                break;

            case TimeOfDay.night:
                RenderSettings.fog = true;

                break;

            default:
                Debug.LogError("Time of day was:" + _time.TimeOfDay);
                break;
        }

    }
}
