using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Implements IObserver in the Observer Pattern
/// </summary>
public interface ISubject
{
    void Subscribe(IObserver _observer);
    void UnSubscribe(IObserver _observer);
    void Notify();

}