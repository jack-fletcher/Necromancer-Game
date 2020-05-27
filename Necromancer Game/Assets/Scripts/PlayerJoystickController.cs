using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerJoystickController : MonoBehaviour
{
    /// <summary>
    /// Reference to the actions bound within SteamVR's input system. Value 1 is left input, value 2 is right input.
    /// </summary>
    [SerializeField] private SteamVR_Action_Vector2[] m_input = null;
    /// <summary>
    /// A set speed float, dictating how fast the player moves.
    /// </summary>
    [SerializeField] private float m_speed = 1;

    [SerializeField] private float m_rotationSpeed = 50;

    [SerializeField] private CharacterController m_cc = null;
    /// <summary>
    /// Reference to the singleton found in Player class.
    /// </summary>
    private Player player;
    private void Awake()
    {
        if (m_cc == null)
        {
          //  m_cc = this.GetComponent<CharacterController>();
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //Reference to the singleton found in Player class
        player = Player.instance;
        //==========================
        //Left Joystick
        //==========================
        //Get the direction the player is currently facing
        Vector3 dir = player.hmdTransform.TransformDirection(new Vector3(m_input[0].axis.x, 0, m_input[0].axis.y));

        ///Move the player by the value returned by joystick movement, * time delta * speed + gravity
        m_cc.Move(m_speed * Time.deltaTime * Vector3.ProjectOnPlane(dir, Vector3.up) + Physics.gravity * Time.deltaTime);
        //==========================
        //Right Joystick
        //==========================

        ///Rotates the player based on joystick movement * time delta * rotation speed
        player.transform.Rotate(Vector3.up * Time.deltaTime * m_rotationSpeed * m_input[1].axis.x);

       
    }
}
