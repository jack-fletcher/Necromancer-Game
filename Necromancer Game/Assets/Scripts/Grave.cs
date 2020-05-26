using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Grave : MonoBehaviour
{
    /// <summary>
    /// The body part hidden within the grave
    /// </summary>
    private GameObject m_bodyPart;
    /// <summary>
    /// The health of the grave - Dictates whether it should break apart or not.
    /// </summary>
    private float m_health;
    /// <summary>
    /// Reference to the head prefab.
    /// </summary>
    [SerializeField] private GameObject m_head = null;
    /// <summary>
    /// Reference to the left arm prefab.
    /// </summary>
    [SerializeField] private GameObject m_leftArm = null;
    /// <summary>
    /// Reference to the right arm prefab.
    /// </summary>
    [SerializeField] private GameObject m_rightArm = null;
    /// <summary>
    /// Reference to the torso prefab.
    /// </summary>
    [SerializeField] private GameObject m_torso = null;
    /// <summary>
    /// Reference to the left leg prefab.
    /// </summary>
    [SerializeField] private GameObject m_leftLeg = null;
    /// <summary>
    /// Reference to the right leg prefab.
    /// </summary>
    [SerializeField] private GameObject m_rightLeg = null;

    /// <summary>
    /// The mesh that replaces this one when its damaged first
    /// </summary>
    [SerializeField] private GameObject m_damagedStage1 = null;
    /// <summary>
    /// Next stage of damage
    /// </summary>
    [SerializeField] private GameObject m_damagedStage2 = null;



    /// <summary>
    /// Sets the health
    /// </summary>
    private void Awake()
    {
        m_health = 5;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyUp(KeyCode.Q))
        {
            TakeDamage(1);
        }

#endif
    }
    /// <summary>
    /// Sets the part and class type types based on parameters, then instantiates it within the grave.
    /// </summary>
    /// <param name="_pt"> The part type to add </param>
    /// <param name="_ct"> The Class type to add </param>
    public void SetBodyPart(Part_Type _pt, Class_Type _ct)
    {
        switch (_pt)
        {
            case Part_Type.head:
                m_bodyPart = m_head;
                break;
            case Part_Type.left_arm:
                m_bodyPart = m_leftArm;

                break;
            case Part_Type.right_arm:
                m_bodyPart = m_rightArm;

                break;
            case Part_Type.left_leg:
                m_bodyPart = m_leftLeg;

                break;
            case Part_Type.right_leg:
                m_bodyPart = m_rightLeg;

                break;
            case Part_Type.torso:
                m_bodyPart = m_torso;

                break;

            default:
                Debug.LogError("_pt was incorrectly formatted. Output was: " + _pt.ToString());
                break;
        }

        m_bodyPart = Instantiate(m_bodyPart);
        ///Test/debug
     //   m_bodyPart = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ///set the new body part to the position of this gameobject
        m_bodyPart.transform.position = transform.position;
        //m_bodyPart.AddComponent<BodyPart>();
        //m_bodyPart.AddComponent<Interactable>();
        //m_bodyPart.AddComponent<Throwable>();
        Rigidbody rb = m_bodyPart.GetComponent<Rigidbody>();
   //     rb.useGravity = false;
   //     rb.constraints = RigidbodyConstraints.FreezeAll;
   //     m_bodyPart.GetComponent<BodyPart>().m_part_Type = _pt;
   //     m_bodyPart.GetComponent<BodyPart>().m_class_Type = _ct;
        m_bodyPart.transform.SetParent(transform);
        m_bodyPart.SetActive(false);

        
        m_bodyPart.name = "Body Part: " + m_bodyPart.GetComponent<BodyPart>().m_part_Type + " (" + m_bodyPart.GetComponent<BodyPart>().m_class_Type + ")";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        m_health = Mathf.Clamp(m_health - damage, 0, m_health);
        Debug.Log("Grave took: " + damage);
        Renderer rend = this.GetComponent<Renderer>();
        if (m_health <= 0)
        {
            Die();
        }
        else if (m_health <= 2)
        {
          //  GetComponent<MeshFilter>().mesh = m_damagedStage2.GetComponent<MeshFilter>().sharedMesh;
#if UNITY_EDITOR
            ///Debug check
            rend.material.color = Color.blue;
#endif
        }
        else if (m_health <= 4)
        {
           // GetComponent<MeshFilter>().mesh = m_damagedStage1.GetComponent<MeshFilter>().sharedMesh; 
#if UNITY_EDITOR
            ///Debug check
            rend.material.color = Color.red;
#endif
        }

    }
   /// <summary>
   /// Disable the mesh renderer and collider of the object and set the body part to be visible on death
   /// </summary>
    private void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;
        m_bodyPart.SetActive(true);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Weapon _weapon = collision.gameObject.GetComponent<Weapon>();
    //    //If the object has the weapon script
    //    if (_weapon != null)
    //    {
    //        TakeDamage(collision.gameObject.GetComponent<Weapon>().m_damage);
    //        Debug.Log("Collided");

    //        ///Get the first point of contact
    //        ContactPoint _contactPoint = collision.contacts[0];

    //        //Play audioclip

    //        //Visual effect? at first point of hit, instantiate sparks or dirt moving or something similar
    //    }
    //    else
    //    {
    //        Debug.Log(collision.gameObject.name);
    //    }
    //}
    
    ///
    /// On Trigger enter, take damage if other gameobject was a weapon
    /// 
    private void OnTriggerEnter(Collider other)
    {
        Weapon _weapon = other.gameObject.GetComponent<Weapon>();
        //If the object has the weapon script
        if (_weapon != null && _weapon.m_dealsGraveDamage == true)
        {
            TakeDamage(other.gameObject.GetComponent<Weapon>().m_damage);
            Debug.Log("Collided");


            //Play audioclip
            //Visual effect? at first point of hit, instantiate sparks or dirt moving or something similar
        }
        else
        {
            Debug.Log(other.gameObject.name);
        }
    }
}
