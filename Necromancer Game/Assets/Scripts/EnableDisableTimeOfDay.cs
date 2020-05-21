using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableTimeOfDay : MonoBehaviour, IObserver
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private TimeManager m_timeManager = null;

    [SerializeField] private TimeOfDay m_activeTime = TimeOfDay.day;

    [SerializeField] private GameObject[] m_objectsToCheck = null;

    public void UpdateState(ISubject _subject)
    {
        EnableDisable();
    }

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
