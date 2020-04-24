using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PlayerHeightController : MonoBehaviour
{
    /// <summary>
    /// A reference to the charactercontroller component.
    /// </summary>
    [SerializeField] private CharacterController m_cc;
    
    /// <summary>
    /// Use the players height? This is estimated using Player.eyeHeight.
    /// </summary>
    [Tooltip("Use the players height? This is estimated using Player.eyeHeight")]
    [SerializeField] private bool m_useRealHeight = false;
    private void Start()
    {
        if (m_cc == null)
        {
            m_cc = this.GetComponent<CharacterController>();
        }
    }


    private void Update()
    {
        UpdateHeight();
    }

    private void UpdateHeight()
    {
        if (m_useRealHeight == true)
        {
            m_cc.height = Player.instance.eyeHeight;
        }
    }
}
