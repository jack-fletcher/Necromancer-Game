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


    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SwapInputs();
        }
#endif
    }

    /// <summary>
    /// Swaps activate controller between vr and first person.
    /// </summary>
    private void SwapInputs()
    {
        if (vr_Controller.activeInHierarchy)
        {
            vr_Controller.SetActive(false);
            fp_Controller.SetActive(true);
        }
        else
        {
            vr_Controller.SetActive(true);
            fp_Controller.SetActive(false);
        }
    }
}
