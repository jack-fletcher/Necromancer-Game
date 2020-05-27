using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener : MonoBehaviour
{

    private List<GameObject> _subscriberObjects = new List<GameObject>();
    private List<string> _subscriberNames = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Subscribe(GameObject _subscriber, string _classname)
    {
        ///Add the gameobject of the subscriber as a listener
        _subscriberObjects.Add(_subscriber);
        ///Add the name of the class thats listening
        _subscriberNames.Add(_classname);
    }

    public void OnCollisionExit(Collision collision)
    {
        
    }

    public void UpdateListeners()
    {
        for (int i = 0; i < _subscriberObjects.Count; i++)
        {
            string _className = _subscriberNames[i];
            Type _classType = Type.GetType(_className);
            _subscriberObjects[i].GetComponent(_className);
        }
    }
}
