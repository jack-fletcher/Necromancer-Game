using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GraveyardGuard : MonoBehaviour
{
    [SerializeField] private GameObject[] m_patrolPoints = null;
    [SerializeField] private CharacterController m_cc = null;
    [SerializeField] private int m_startPoint = 0;
    [SerializeField] private int m_currentState = 0;
     private int m_movementSpeed = 0;
    [SerializeField] private int m_baseMovementSpeed = 0;
    [SerializeField] private int m_highAlertSpeed = 0;
    [SerializeField] private int m_scanRadius = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_currentState = m_startPoint;
        m_movementSpeed = m_baseMovementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBetweenPoints(m_currentState);
    }

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

        else if (Vector3.Distance(gameObject.transform.position, _goal.position)< 1.5f)
        {
            //check if its a player

        if (_goal.gameObject == Player.instance)
            {

            }
        else if (m_currentState < m_patrolPoints.Length - 1)
            {
                m_currentState++;
            }
            else
            {
                m_currentState = 0;
            }
        
        }
    }

    private GameObject CheckForPoi()
    {
        Collider[] _hitColliders = Physics.OverlapSphere(transform.position, m_scanRadius);

        for (int i = 0; i < _hitColliders.Length; i++)
        {
            if (_hitColliders[i].gameObject == Player.instance)
            {
                //RaycastHit _hit;
                //if (Physics.Raycast(transform.position, _hitColliders[i].transform.position, out _hit, m_scanRadius * 2))
                //{
                //    if (_hit.transform.gameObject == Player.instance)
                //    {
                        return _hitColliders[i].gameObject;
                   // }
                }

         
        }
        
        return null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_scanRadius);
    }
}
