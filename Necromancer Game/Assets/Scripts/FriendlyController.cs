using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FriendlyController : MonoBehaviour
{


    private CharacterController m_cc;

    private Animator m_anim;

    private CharacterStats m_cs;

    public int m_startIndex = 0;
    private int m_currentState;

    public Vector3 m_test;
    // Start is called before the first frame update
    void Start()
    {
        m_currentState = m_startIndex;
        m_cc = this.GetComponent<CharacterController>();
        m_cs = this.GetComponent<CharacterStats>();
        m_anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_currentState < NavigationManager.Instance.m_navigationPoints.Length){
            SimpleMove(m_currentState);
        }
        else
        {
            m_anim.SetBool("isWalking", false);
           
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void SimpleMove(int goalIndex)
    {
        Transform _goal = NavigationManager.Instance.m_navigationPoints[goalIndex].transform;
        ///If the player isn't at the goal state, move towards it
        Vector3 moveVector = _goal.position - transform.position;



        GameObject _enemyFound = CheckForEnemy();
        ///If an enemy is found within your check radius, move towards that instead.
        if (_enemyFound == true)
        {
            moveVector = _enemyFound.transform.position - transform.position;
            _goal = _enemyFound.transform;
        }

        moveVector = moveVector.normalized * m_cs.m_movementSpeed;


        ///If the character controller isn't grounded, add gravity.
        if (!m_cc.isGrounded)
        {
            moveVector += Physics.gravity;
        }

        ///If the distance between this object and the target state is more than the minimum move distance of 1 units, move
        if (Vector3.Distance(gameObject.transform.position, _goal.position) > 1f)
        {

            m_cc.Move(moveVector * Time.deltaTime);
            m_anim.SetBool("isWalking", true);
            m_anim.SetBool("isAttacking", false);
            transform.LookAt(_goal);

        }

        ///Otherwise, if the target is a character, attack it. If not, change the target state.
        ///At this point, you're within the targets deadzone, so any data you may wish to collect about the waypoint
        ///Can be collected.
        else
        {
            if (_goal.GetComponent<CharacterStats>() != null) {
                m_cs.Attack(_enemyFound.GetComponent<CharacterStats>());
                m_anim.SetBool("isWalking", false);
                m_anim.SetBool("isAttacking", true);
            }
            else {
                m_currentState++;
            } 

        }

       



    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private GameObject CheckForEnemy()
    {
        int _radius = 5;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].tag == "Enemy")
            {
                return hitColliders[i].gameObject;
            }
        }

        return null;
    }

    /// <summary>
    /// Draws a sphere around the character so you can see within the editor whether the range of CheckForEnemy() is accurate
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, 5);
    }
}
