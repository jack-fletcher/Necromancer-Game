using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Implements IObserver in the Observer Pattern
/// </summary>
public interface IObserver
{
    void UpdateState(ISubject _subject);
}
