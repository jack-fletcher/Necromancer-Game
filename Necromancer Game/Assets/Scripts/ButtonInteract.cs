using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
    public TimeManager m_timeManager;
    /// <summary>
    /// Test class - Changes the time of day.
    /// </summary>
    public void OnButtonDown()
    {
        m_timeManager.ChangeTime();
    }

    public void OnButtonUp()
    {

    }

    public void OnButtonHold()
    {

    }


}
