 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CharacterStats))]
public class EnemyController : MonoBehaviour
{
    /// <summary>
    /// Reference to a character controller
    /// </summary>
    private CharacterController m_cc;
    /// <summary>
    /// Reference to the characters stats script
    /// </summary>
    private CharacterStats m_cs;
    /// <summary>
    /// The start index of the navigation instances nav points that the character starts at
    /// </summary>
    private int m_startIndex;
    /// <summary>
    /// Reference to the animator component
    /// </summary>
    private Animator m_anim;
    /// <summary>
    /// Does the unit patrol between two points? //TODO
    /// </summary>
    [Tooltip("Does the unit patrol between two points?")]
    [SerializeField] private bool m_patrols = false;
    /// <summary>
    /// Does the unit move towards enemy spawn?
    /// </summary>
    [Tooltip("Does the unit move towards the enemy spawn? ")]
    [SerializeField] private bool m_MovesTowardsEnemyStart = false;
    /// <summary>
    /// Is the unit stationary
    /// </summary>
    [SerializeField] private bool m_stationary = true;
    public int m_currentState;
    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        m_startIndex = NavigationManager.Instance.m_navigationPoints.Length - 1;
        m_currentState = m_startIndex;
        m_cc = this.GetComponent<CharacterController>();
        m_cs = this.GetComponent<CharacterStats>();
        m_anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SimpleMove(m_currentState);
          //  m_anim.SetBool("isWalking", false);
    }

    /// <summary>
    /// Moves towards a goal index, checking for points of interest along the way. If one is found, that becomes the goal.
    /// </summary>
    void SimpleMove(int goalIndex)
    {
        Transform _goal;
        if (m_MovesTowardsEnemyStart)
        {
            _goal = NavigationManager.Instance.m_navigationPoints[goalIndex].transform;
        }
        else if (m_patrols)
        {
            _goal = Patrol();
        }
        else
        {
            ///TODO: Change this, though currently it should go to its spawn point then when it finishes an enemy,
            ///return to this point, which works.
            _goal = NavigationManager.Instance.m_navigationPoints[NavigationManager.Instance.m_navigationPoints.Length - 1].transform;
        }
        ///If the player isn't at the goal state, move towards it
        Vector3 moveVector = _goal.position - transform.position;



        GameObject _enemyFound = CheckForEnemy();
        ///If an enemy is found within your check radius, move towards that instead.
        if (_enemyFound == true)
        {
            moveVector = _enemyFound.transform.position - transform.position;
            _goal = _enemyFound.transform;
        }


        //Normalise the speed based on the characters movement speed
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

        ///Otherwise, if the target is a character, attack it. If not, change the target state as you reached your goal state
        else
        {
            if (_goal.GetComponent<CharacterStats>() != null)
            {
                m_cs.Attack(_enemyFound.GetComponent<CharacterStats>());
                m_anim.SetBool("isWalking", false);
                m_anim.SetBool("isAttacking", true);
            }
            else if (m_currentState >= 0)
            {
                m_currentState--;
                m_anim.SetBool("isWalking", false);
                m_anim.SetBool("isAttacking", false);
            }
            else
            {
                m_anim.SetBool("isWalking", false);
                m_anim.SetBool("isAttacking", false);
            }
        }

    }
    /// <summary>
    /// On collision with a weapon, take damage
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Weapon>() != null)
        {
            m_cs.TakeDamage(collision.gameObject.GetComponent<Weapon>().m_damage, collision.gameObject.GetComponent<Weapon>().m_attackType);
        }
    }
    /// <summary>
    /// Patrols between two points //TODO
    /// </summary>
    /// <returns></returns>
    private Transform Patrol()
    {


        return transform;
    }

    /// <summary>
    /// Checks for an enemy within a sphere radius
    /// </summary>
    /// <returns>returns the GameObject that is found</returns>
    private GameObject CheckForEnemy()
    {
        int _radius = 5;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].tag == "Friendly")
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
