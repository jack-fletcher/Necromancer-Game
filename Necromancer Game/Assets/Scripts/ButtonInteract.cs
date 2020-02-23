using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
    public TimeManager m_timeManager;
    
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
