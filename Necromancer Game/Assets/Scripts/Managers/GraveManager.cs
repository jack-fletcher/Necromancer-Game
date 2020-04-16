using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GraveManager : MonoBehaviour

{
    /// <summary>
    /// 
    /// </summary>
    private Grave m_grave;
    /// <summary>
    /// 
    /// </summary>
    private GameObject[] m_graveSpots;

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        m_graveSpots = GameObject.FindGameObjectsWithTag("Grave");
    }
    /// Start is called before the first frame update
    void Start()
    {
        Setup();       
       
    }

    private void Setup()
    {
        int counter = 1;
        foreach (GameObject go in m_graveSpots)
        {
            Grave _grave = go.GetComponentInChildren<Grave>();
            Gravestone _gravestone = go.GetComponentInChildren<Gravestone>();
            int _idx = UnityEngine.Random.Range(0, Enum.GetValues(typeof(Part_Type)).Length);
            Part_Type _pt = (Part_Type)_idx;
            int idx = UnityEngine.Random.Range(0, Enum.GetValues(typeof(Class_Type)).Length);
            Class_Type _ct = (Class_Type)idx;

            ///Debug
            _ct = Class_Type.knight;
            ///Set text on grave
            string _ctName = _ct.ToString();


            counter++;
            string query = $"(//*[@id='{_ctName}']//*[@id='GraveText'])[{counter}]";
            string graveText = XMLManager.Instance.ReadSingleNodeData(query);

            if (graveText == null)
            {
                graveText = "Dummy Text";
            }

            _gravestone.SetCanvasText(graveText);

            ///Add body part to grave
            _grave.SetBodyPart(_pt, _ct);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }


}
