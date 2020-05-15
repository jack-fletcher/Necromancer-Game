using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TowerDefence : MonoBehaviour
{
    [SerializeField] private TimeManager m_timeManager = null;
    [SerializeField] private TeleportToArea m_teleportToArea = null;
    [SerializeField] private UnitInventory m_playerUnits = null;
    [SerializeField] private Transform m_towerDefenceStart = null;

    [SerializeField] private GameObject m_testObject = null;

    
    public void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyUp(KeyCode.F))
        {
            m_playerUnits.m_units.Add(m_testObject);
        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            OnButtonPress();
        }
#endif
    }

    public void OnButtonPress()
    {
        m_timeManager.ChangeTime(TimeOfDay.night);
        m_teleportToArea.EnterRegion(Player.instance.gameObject);

        UnitManager.Instance.CreateFriendlyUnits();
    }



}
