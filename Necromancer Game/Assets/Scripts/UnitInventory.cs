using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInventory : MonoBehaviour
{
    /// <summary>
    /// Players unit inventory
    /// </summary>
    public List<GameObject> m_units = new List<GameObject>();
    /// <summary>
    /// Spawn rate of units
    /// </summary>
    public float m_spawnRate;
}
