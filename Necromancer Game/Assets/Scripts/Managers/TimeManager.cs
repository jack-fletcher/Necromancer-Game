using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

///Created using Code First's Observer Pattern example https://www.youtube.com/watch?v=oVAFvyICmbw

/// <summary>
/// Manages the time of day within the game
/// </summary>
public class TimeManager : MonoBehaviour, ISubject
{
    /// <summary>
    /// The current time of day. Probably only day or night, but there's scope for different times of day.
    /// </summary>
    public TimeOfDay TimeOfDay {
        get { return _timeOfDay; }
        private set { _timeOfDay = value;
            Notify();
        }
    }
    private TimeOfDay _timeOfDay;

    private TimeOfDay m_TimeOfDay;
    private void Start()
    {

    }
    /// <summary>
    /// Subscrives an observer
    /// </summary>
    /// <param name="_observer"></param>
    public void Subscribe(IObserver _observer)
    {
        _observers.Add(_observer);
    }

    /// <summary>
    /// Unsubscribes an observer
    /// </summary>
    /// <param name="_observer"></param>
    public void UnSubscribe(IObserver _observer)
    {
        if (_observers.Contains(_observer))
        {
            _observers.Remove(_observer);
        }
    }
    
    /// <summary>
    /// Notifies each observer for a change in state
    /// </summary>
    public void Notify()
    {
        //foreach (IObserver _observer in _observers)
        //{
        //    _observer.UpdateState(this);
        //}
        if (_observers.Count > 0)
        {
            foreach (IObserver _observer in _observers)
            {
                _observer.UpdateState(this);
            }
        }
        else
        {
            Debug.Log("No observers");
        }
    }
    /// <summary>
    /// List of all observers
    /// </summary>
    public List<IObserver> _observers;

    /// <summary>
    /// Constructor to initialise list
    /// </summary>
    public TimeManager()
    {

    _observers = new List<IObserver>();
        }

    public void ChangeTime()
    {
        switch (TimeOfDay)
        {
            case TimeOfDay.day:
                TimeOfDay = TimeOfDay.night;
                break;

            case TimeOfDay.night:
                TimeOfDay = TimeOfDay.day;
                break;

            default:
                Debug.LogError("ERROR: Time of day was:" + TimeOfDay);
                break;
        }
    }

    public void ChangeTime(TimeOfDay _time)
    {
        switch (_time)
        {
            case TimeOfDay.night:
                TimeOfDay = TimeOfDay.night;
                break;

            case TimeOfDay.day:
                TimeOfDay = TimeOfDay.day;
                break;

            default:
                Debug.LogError("ERROR: Time of day was:" + TimeOfDay);
                break;
        }
    }
}
