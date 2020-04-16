 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CharacterStats))]
public class EnemyController : MonoBehaviour
{

    private CharacterController m_cc;

    private CharacterStats m_cs;

    private int m_startIndex;

    [Tooltip("Does the unit patrol between two points?")]
    [SerializeField] private bool m_patrols;
    [Tooltip("Does the unit move towards the enemy spawn? ")]
    [SerializeField] private bool m_MovesTowardsEnemyStart;
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

    }

    // Update is called once per frame
    void Update()
    {
        if (m_currentState >= 0)
        {
            SimpleMove(m_currentState);
        }
    }

    /// <summary>
    /// 
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



        ///If the distance between this object and the target state is more than the minimum move distance of 1 units, move
        if (Vector3.Distance(gameObject.transform.position, _goal.position) > 1f)
        {

            m_cc.Move(moveVector * Time.deltaTime);
            transform.LookAt(_goal);

        }

        ///Otherwise, if the target is a character, attack it. If not, change the target state as you reached your goal state
        else
        {
            if (_goal.GetComponent<CharacterStats>() != null)
            {
                m_cs.Attack(_enemyFound.GetComponent<CharacterStats>());
            }
            else
            {
                m_currentState--;
            }

        }





    }

    private Transform Patrol()
    {


        return transform;
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
