using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBarGUI : MonoBehaviour
{
    /// <summary>
    /// Reference to the stat bar slider
    /// </summary>
    [SerializeField] private Slider m_statBar = null;
    /// <summary>
    /// Reference to the objects characterstats script
    /// </summary>
    [SerializeField] private CharacterStats m_cc = null;
    // Start is called before the first frame update
    void Start()
    {
        m_statBar.minValue = 0;
        m_statBar.maxValue = m_cc.m_maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        m_statBar.value = m_cc.m_currentHealth;
    }
}
