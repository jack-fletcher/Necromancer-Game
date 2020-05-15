using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Throwable))]
public class Weapon : MonoBehaviour
{

    public float m_damage;
    public Attack_Type m_attackType;
    public bool m_dealsGraveDamage = false;
    [Tooltip("Does the weapon get destroyed on use?")]
    [SerializeField] private bool m_singleUse = false;
    
    public float DealDamage()
    {
        if (m_singleUse)
        {
            Invoke("Disable", 0.2f);
        }
        return m_damage;
    }

    private void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
