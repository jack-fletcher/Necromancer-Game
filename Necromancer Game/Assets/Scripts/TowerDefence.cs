using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TowerDefence : MonoBehaviour
{
    /// <summary>
    /// Reference to timemanager
    /// </summary>
    [SerializeField] private TimeManager m_timeManager = null;
    /// <summary>
    /// TeleportToArea reference
    /// </summary>
    [SerializeField] private TeleportToArea m_teleportToArea = null;
    /// <summary>
    /// Reference to the players unit inventory
    /// </summary>
    [SerializeField] private UnitInventory m_playerUnits = null;
    /// <summary>
    /// TODO remove
    /// </summary>
    [SerializeField] private GameObject m_testObject = null;

    
    public void Update()
    {
#if UNITY_EDITOR
        //if (Input.GetKeyUp(KeyCode.F))
        //{
        //    m_playerUnits.m_units.Add(m_testObject);
        //}

        //if (Input.GetKeyUp(KeyCode.G))
        //{
        //    OnButtonPress();
        //}
#endif
    }
    /// <summary>
    /// On button press, start tower defence mode
    /// </summary>
    public void OnButtonPress()
    {
        m_timeManager.ChangeTime(TimeOfDay.night);
        m_teleportToArea.EnterRegion(Player.instance.gameObject);

        UnitManager.Instance.CreateUnits();
        
    }



}
