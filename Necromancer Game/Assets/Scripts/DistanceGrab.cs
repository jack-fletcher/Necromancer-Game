﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

/// <summary>
/// Distance grabbing that can be used for when the object is only slightly out of the players reach, i.e outside of Steam Chaperone or Oculus Guardian space
/// </summary>
public class DistanceGrab : MonoBehaviour
{
    [SerializeField] private float m_length = 10f;
    /// <summary>
    /// Hand that's grabbing things
    /// </summary>
    private Hand m_hand;
    /// <summary>
    /// Interactable component of the object thats being held
    /// </summary>
    private Interactable m_object;
    private void Awake()
    {
        m_hand = this.GetComponent<Hand>();
    }
    /// <summary>
    /// If Raycast hits something that has interactable script, check if hand is holding something and if not, attach hit object 
    /// </summary>
    private void Update()
    {
        RaycastHit _hit;
        if (m_hand.GetGrabStarting() != GrabTypes.None)
        {
            if (Physics.Raycast(this.transform.position, transform.forward, out _hit, m_length) && m_hand.currentAttachedObject == null)
            {
                if (_hit.collider.gameObject.GetComponent<Interactable>() != null)
                {
                    m_object = _hit.collider.gameObject.GetComponent<Interactable>();
                    m_hand.AttachObject(m_object.gameObject, m_hand.GetGrabStarting());
                    m_hand.HoverLock(m_object);
                }
            }
        }
        else if (m_hand.IsGrabEnding(m_object.gameObject))
        {
            m_hand.DetachObject(gameObject);
            m_hand.HoverUnlock(m_object);
        }
    }
}
