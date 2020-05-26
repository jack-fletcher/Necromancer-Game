using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableTimeOfDay : MonoBehaviour, IObserver
{
    /// <summary>
    /// Reference to the timemanager singleton
    /// </summary>
    [SerializeField] private TimeManager m_timeManager = null;
    /// <summary>
    /// Active time of day - Default is day
    /// </summary>
    [SerializeField] private TimeOfDay m_activeTime = TimeOfDay.day;
    /// <summary>
    /// Objects to disable/enable
    /// </summary>
    [SerializeField] private GameObject[] m_objectsToCheck = null;
    /// <summary>
    /// Method that's called when state is updated
    /// </summary>
    /// <param name="_subject"></param>
    public void UpdateState(ISubject _subject)
    {
        EnableDisable();
    }
    /// <summary>
    /// Subscribe to time manager whenever this is activated
    /// </summary>
    private void Awake()
    {
        m_timeManager.Subscribe(this);
        EnableDisable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Enables or disables an object based on time of day and active time
    /// </summary>
    void EnableDisable()
    {
        if (m_activeTime != m_timeManager.TimeOfDay)
        {
            foreach (var item in m_objectsToCheck)
            {
                item.SetActive(false);
            }
        }
        else
        {
            foreach (var item in m_objectsToCheck)
            {
                item.SetActive(true);
            }
        }



    }
}
