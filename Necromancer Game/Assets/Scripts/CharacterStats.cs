using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Meant to be inherited from. Shows stats of a character.
/// </summary>
public class CharacterStats : MonoBehaviour
{
    public Class_Type m_characterType;
    #region Attributes
    /// <summary>
    /// The players endurance level. Controls the health of the character and damage resistance.
    /// </summary>
    public float m_endurance { get; set; } = 1;
    /// <summary>
    /// The dexterity of the character. Controls movement and attack speed.
    /// </summary>
    public float m_dexterity { get; set; } = 1;
    /// <summary>
    /// The strength of the character. affects physical damage.
    /// </summary>
    public float m_strength { get; set; } = 1;
    /// <summary>
    /// The intelligence of the character. Currently unused, but affects magical damage and magical resistance.
    /// </summary>
    public float m_intelligence { get; set; } = 1;
    #endregion

    #region Stats derived from Attributes
    /// <summary>
    /// The maximum health of the character - Governed by the endurance stat.
    /// </summary>
    public float m_maxHealth { get; set; } = 0;

    public float m_currentHealth { get;  set; } = 0;
    /// <summary>
    /// The movement speed of the character - Governed by the dexterity stat.
    /// </summary>
    public float m_movementSpeed { get;  set; } = 0;
    /// <summary>
    /// The attack speed of the character - Governed by the dexterity stat.
    /// </summary>
    public float m_attackSpeed { get;  set; } = 0;
    /// <summary>
    /// The physical damage this character deals - Governed by strength.
    /// </summary>
    public float m_physicalDamage { get;  set; } = 0;
    /// <summary>
    /// The magical damage this character deals - Governed by intelligence, not used in M.V.P.
    /// </summary>
    public float m_spellDamage { get;  set; } = 0;
    /// <summary>
    /// The amount of physical damage as a percentage that the character resists.
    /// </summary>
    public float m_physicalResist { get;  set; } = 0;
    /// <summary>
    /// The amount of magical damage as a percentage that the character resists.
    /// </summary>
    public float m_spellResist { get;  set; } = 0;
    #endregion
    /// <summary>
    /// The type of attack the character deals. Currently only physical, however has been added for later iterations.
    /// </summary>
    public Attack_Type m_attackType;
    /// <summary>
    /// Level of the character - Is not used in M.V.P, however may be used in M.A.P.
    /// </summary>
    public int m_level = 1;

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        CalculateStats();
    }


    private float m_timeTillAttack;
    public void Attack(CharacterStats target)
    {
        if (Time.time >= m_timeTillAttack)
        {
            m_timeTillAttack = Time.time + m_attackSpeed;

            DealDamage(target);
        }

        else
        {
        //    m_timeTillAttack = Time.time + m_attackSpeed;
        }
    }

    /// <summary>
    /// Removes the specified amount of health from the characters health.
    /// </summary>
    /// <param name="damage"> The damage that is taken. </param>
    public void TakeDamage(float damage, Attack_Type _at)
    {
        ///Calculate the resistance that the character takes from that type of attack
        float res = 1;
        if (_at.ToString() == "Physical")
        {
            res = m_physicalResist / 100;
        }
        else if (_at.ToString() == "Magical")
        {
            res = m_spellResist / 100;
        }
        else if (_at.ToString() == "World")
        {
            res = 1;
        }
        else
        {
            Debug.Log("Input incorrect. Actual input was: " + _at.ToString());
        }
        ///Remove the amount of resistance from the damage
        damage *= res;
        m_currentHealth = Mathf.Clamp(m_currentHealth - damage, 0, m_currentHealth);
   //     Debug.Log(this.gameObject.name + " took " + damage +  _at.ToString() + " damage." );
        if (m_currentHealth <= 0)
        {
            Die();
        }

        Renderer[] _renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer rend in _renderers)
        {
            StartCoroutine("Flash", rend);
           // rend.material.color = _col;
        }
    }

    private void SetUpColours()
    {
        Renderer[] m_renderers = GetComponentsInChildren<Renderer>();

        Color[] m_colours = new Color[m_renderers.Length];

        for (int i = 0; i < m_renderers.Length; i++)
        {
            m_colours[i] = m_renderers[i].material.color;
        }
    }

    IEnumerator Flash(Renderer rend)
    {
        //TODO FIX THIS: If character gets hit again while already flashing, the original colour is set to flashed colour. //TEMP: Change _col to Color.white, 
        //which hasn't yet been changed and likely wont, so won't have any impact, however would prefer not to do this in future. Low priority fix
       // Color _col = rend.material.color;
        rend.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rend.material.color = Color.white;
    }
    /// <summary>
    /// Kills the character.
    /// </summary>
    public void Die()
    {
   //     Debug.Log(this.gameObject.name + " was killed.");
        this.gameObject.SetActive(false);
        UnitManager.Instance.MediateGame();
    }

    public void DealDamage(CharacterStats _target)
    {
        _target.TakeDamage(m_physicalDamage, m_attackType);
     //   Debug.Log(transform.name + " Is dealing damage.");
    }

    

    public virtual void CalculateStats()
    {
        switch (m_characterType) {
            case Class_Type.knight:

                ///Decide attack type
                m_attackType = Attack_Type.Physical;
                ///Calculate attributes
                m_endurance = Random.Range(7, 10);
                m_dexterity = Random.Range(4, 6);
                m_strength = Random.Range(5, 7);
                m_intelligence = Random.Range(2, 4);

                break;
            case Class_Type.berserker:

                ///Decide attack type
                m_attackType = Attack_Type.Physical;
                ///Calculate attributes
                m_endurance = Random.Range(5, 7);
                m_dexterity = Random.Range(4, 5);
                m_strength = Random.Range(7, 10);
                m_intelligence = Random.Range(2, 3);

                break;

            case Class_Type.thief:

                ///Decide attack type
                m_attackType = Attack_Type.Physical;
                ///Calculate attributes
                m_endurance = Random.Range(3, 5);
                m_dexterity = Random.Range(7, 10);
                m_strength = Random.Range(4, 6);
                m_intelligence = Random.Range(2, 3);

                break;
            default:
                Debug.Log("Error: Character type not correct");
                break;
        }



    
        ///Calculate Stats from attributes

        m_maxHealth = m_endurance * 5;
        m_currentHealth = m_maxHealth;
        m_movementSpeed = m_dexterity / 2;
        m_attackSpeed = m_dexterity / 2;
        m_physicalDamage = m_strength / 2;
        m_spellDamage = m_intelligence / 2;
        m_physicalResist = m_endurance * 10;
        m_spellResist = m_intelligence * 10;

    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Weapon>() != null)
        {
            Weapon _weapon = collision.gameObject.GetComponent<Weapon>();
            TakeDamage(_weapon.m_damage, _weapon.m_attackType);
        }
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(10, Attack_Type.Physical);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            TakeDamage(10, Attack_Type.Magical);

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(10, Attack_Type.World);

        }
#endif
    }
}
