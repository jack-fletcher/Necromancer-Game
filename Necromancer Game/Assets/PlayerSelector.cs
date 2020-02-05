using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.XR;

public class PlayerSelector : MonoBehaviour
{
    /// <summary>
    /// If a vr headset is connected, the game will default to this character
    /// </summary>
    [SerializeField]
    private GameObject vr_Controller;
    /// <summary>
    /// Otherwise, a first person character will be spawned - This is mostly for checking visual bugs.
    /// </summary>
    [SerializeField]
    private GameObject fp_Controller;

    /// <summary>
    /// Occurs before the first start method
    /// </summary>
    private void Awake()
    {

    }

}
