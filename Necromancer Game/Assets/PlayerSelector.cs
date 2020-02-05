using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
