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
    /// 
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
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    TakeDamage(5);
        //}

#endif
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_pt"></param>
    /// <param name="_ct"></param>
    public void SetBodyPart(Part_Type _pt, Class_Type _ct)
    {

        ///Test/debug
        m_bodyPart = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ///set the new body part to the position of this gameobject
        m_bodyPart.transform.position = transform.position;
        m_bodyPart.AddComponent<BodyPart>();
        m_bodyPart.AddComponent<Interactable>();
        m_bodyPart.AddComponent<Throwable>();
        Rigidbody rb = m_bodyPart.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        m_bodyPart.GetComponent<BodyPart>().m_part_Type = _pt;
        m_bodyPart.GetComponent<BodyPart>().m_class_Type = _ct;
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
#if UNITY_EDITOR
            ///Debug check
            rend.material.color = Color.blue;
#endif
        }
        else if (m_health <= 4)
        {
#if UNITY_EDITOR
            ///Debug check
            rend.material.color = Color.red;
#endif
        }

    }
   /// <summary>
   /// 
   /// </summary>
    private void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
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

    private void OnTriggerEnter(Collider other)
    {
        Weapon _weapon = other.gameObject.GetComponent<Weapon>();
        //If the object has the weapon script
        if (_weapon != null)
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
