using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Throwable))]
public class Weapon : MonoBehaviour
{

    /// <summary>
    /// Damage of weapon
    /// </summary>
    public float m_damage;
    /// <summary>
    /// The attack type of weapon
    /// </summary>
    public Attack_Type m_attackType;
    /// <summary>
    /// Can it be used to destroy graves?
    /// </summary>
    public bool m_dealsGraveDamage = false;
    [Tooltip("Does the weapon get destroyed on use?")]
    
    ///
    /// Is the object single use?
    /// 
    [SerializeField] private bool m_singleUse = false;
    
    /// <summary>
    /// Deals damage to target
    /// </summary>
    /// <returns></returns>
    public float DealDamage()
    {
        if (m_singleUse)
        {
            Invoke("Disable", 0.2f);
        }
        return m_damage;
    }

    /// <summary>
    /// Disables this object
    /// </summary>
    private void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
