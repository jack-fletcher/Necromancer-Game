using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using TMPro;
public class GraveyardGuard : MonoBehaviour
{
    [Header("Pathfinding")]
    ///Scan radius of GameObject
    [SerializeField] private int m_scanRadius = 0;
    /// <summary>
    /// The points the guard will patrol between
    /// </summary>
    [SerializeField] private GameObject[] m_patrolPoints = null;
    /// <summary>
    /// Gameobject to signify the eye level of guard
    /// </summary>
    [SerializeField] private Transform m_eyeLevel = null;
    /// <summary>
    /// The point to teleport the player to upon being found.
    /// </summary>
    [SerializeField] private TeleportToArea m_tp = null;
    [Header("Unit Stats")]
    ///Reference to a character controller
    [SerializeField] private CharacterController m_cc = null;
    /// <summary>
    /// Start point within his navigation array
    /// </summary>
    [SerializeField] private int m_startPoint = 0;
    /// <summary>
    /// The current navigation point state
    /// </summary>
    [SerializeField] private int m_currentState = 0;
    /// <summary>
    /// The current movement speed of the guard
    /// </summary>
     private int m_movementSpeed = 0;
    /// <summary>
    /// Base movement speed of the guard
    /// </summary>
    [SerializeField] private int m_baseMovementSpeed = 0;
    /// <summary>
    /// The high alert movement speed of the guard
    /// </summary>
    [SerializeField] private int m_highAlertSpeed = 0;


    
    [Header("Canvas Variables ")]
    ///Reference to the canvas GameObject attached to the guard
    [SerializeField] private Canvas m_textCanvas = null;
    /// <summary>
    /// Reference to the text on canvas gameobject
    /// </summary>
    [SerializeField] private TextMeshProUGUI m_text = null;
    /// <summary>
    /// bool to specify whether the player was seen recently
    /// </summary>
    [SerializeField] private bool m_wasUnitLastSeen = false;
    // Start is called before the first frame update
    void Start()
    {
        m_textCanvas.enabled = false;
        m_currentState = m_startPoint;
        m_movementSpeed = m_baseMovementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBetweenPoints(m_currentState);
    }

    /// <summary>
    /// Moves the guard between each point in his patrol points array, by moving to the goal index.
    /// </summary>
    /// <param name="_goalIndex"></param>
    private void MoveBetweenPoints(int _goalIndex)
    {
        Transform _goal = m_patrolPoints[_goalIndex].transform;



        if (CheckForPoi() != null)
        {
            GameObject _poi = CheckForPoi();
            _goal = _poi.transform;
            m_movementSpeed = m_highAlertSpeed;
        }
        else
        {
            m_movementSpeed = m_baseMovementSpeed;
        }

        Vector3 _moveVector = _goal.position - transform.position;

        if (!m_cc.isGrounded)
        {
            _moveVector += Physics.gravity;
        }
        _moveVector = _moveVector.normalized * m_movementSpeed;
        if (Vector3.Distance(gameObject.transform.position, _goal.position) > 1f)
        {
                m_cc.Move(_moveVector * Time.deltaTime);
                transform.LookAt(_goal);

        }

        else if (Vector3.Distance(gameObject.transform.position, _goal.position)< 2f)
        {
            //check if its a player

        if (_goal.gameObject.tag == "Player")
            {
                m_tp.EnterRegion();

            }
        else if (m_currentState < m_patrolPoints.Length - 1)
            {
                m_currentState++;
                m_textCanvas.enabled = false;
            }
            else
            {
                m_currentState = 0;
                m_textCanvas.enabled = false;
            }
        
        }
    }

    /// <summary>
    /// Checks for points of interest - I.E, player
    /// </summary>
    /// <returns></returns>
    private GameObject CheckForPoi()
    {
        Collider[] _hitColliders = Physics.OverlapSphere(transform.position, m_scanRadius);

        for (int i = 0; i < _hitColliders.Length; i++)
        {
            if (_hitColliders[i].gameObject.tag == "Player")
            {


                RaycastHit _hit;

                ///Bit shifts index of layer 10 to get a bitmask for layer 10 - unit
                LayerMask _mask = 1 << 10;

                ///Invert bitmask to collide against everything except this layer - Stops it from colliding with guard
                _mask = ~_mask;
                float _distance = Vector3.Distance(m_eyeLevel.position, Player.instance.transform.position);
                Debug.DrawLine(m_eyeLevel.position, Player.instance.transform.position, Color.blue);
                if (Physics.Linecast(m_eyeLevel.position, Player.instance.transform.position, out _hit))
                {
                    ///Get the root objects gameobject tag
                    if (_hit.transform.root.gameObject.tag == "Player")
                    {
                        Debug.Log("Player Seen");
                        m_textCanvas.enabled = true;
                        m_text.fontSize = 200;
                        m_text.text = "Hey you!";
                        m_wasUnitLastSeen = true;
                        return _hitColliders[i].gameObject;
                    }

                }

            }

         
        }

        if (m_wasUnitLastSeen == true)
        {
            m_textCanvas.enabled = true;
            m_text.fontSize = 160;
            m_text.text = "Must've been the wind...";
        }
        m_wasUnitLastSeen = false;

        return null;
    }
    /// <summary>
    /// Shows navigation path
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_scanRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(m_eyeLevel.position, Player.instance.gameObject.transform.position);
    }
}
