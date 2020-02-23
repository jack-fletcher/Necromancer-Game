﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Created using Code First's Observer Pattern example https://www.youtube.com/watch?v=oVAFvyICmbw

/// <summary>
/// Manages the time of day within the game
/// </summary>
public class TimeManager : MonoBehaviour, ISubject
{
    /// <summary>
    /// The current time of day. Probably only day or night, but there's scope for different times of day.
    /// </summary>
    public string TimeOfDay {
        get { return _timeOfDay; }
        private set { _timeOfDay = value;
            Notify();
        }
    }
    private string _timeOfDay;


    private void Start()
    {
        TimeOfDay = "day";
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
        if (TimeOfDay == "day")
        {
            TimeOfDay = "night";
        } 
        else if (_timeOfDay == "night")
        {
            TimeOfDay = "day";
        }
        else
        {
            Debug.LogError("ERROR: TimeOfDay incorrectly set. Time of day is: " + TimeOfDay);
        }
    }
}
