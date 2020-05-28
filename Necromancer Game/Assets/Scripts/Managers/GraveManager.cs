using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GraveManager : MonoBehaviour

{
    /// <summary>
    /// A reference to all graves within the scene
    /// </summary>
    private GameObject[] m_graveSpots;

    /// <summary>
    /// Occurs when script is loaded and adds all graves to m_graveSpots
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

    
    /// <summary>
    /// Sets up each grave with a class and part type and adds text to the gravestone
    /// </summary>
    private void Setup()
    {
        int counter = 0;

        int _knightCounter = 0;
        int _bersCounter = 0;
        int _thiefCounter = 0;

        foreach (GameObject go in m_graveSpots)
        {
            Grave _grave = go.GetComponentInChildren<Grave>();
            Gravestone _gravestone = go.GetComponentInChildren<Gravestone>();
            int _idx = UnityEngine.Random.Range(0, Enum.GetValues(typeof(Part_Type)).Length);
            
            Part_Type _pt = (Part_Type)_idx;
            int idx = UnityEngine.Random.Range(0, Enum.GetValues(typeof(Class_Type)).Length);

            Class_Type _ct = (Class_Type)idx;
            switch (_ct)
            {
                case Class_Type.berserker:
                    _bersCounter++;
                    counter = _bersCounter;
                    break;
                case Class_Type.knight:
                    _knightCounter++;
                    counter = _knightCounter;

                    break;

                case Class_Type.thief:
                    _thiefCounter++;
                    counter = _thiefCounter;

                    break;
            }
            ///Debug
        //    _ct = Class_Type.knight;
            ///Set text on grave
            string _ctName = _ct.ToString();

            string query = $"(//*[@id='FriendlyUnits']//*[@id='{_ctName}']//*[@id='GraveText'])[{counter}]";
            string graveText = XMLManager.Instance.ReadSingleNodeData(query);

            if (graveText == null)
            {
                Debug.LogError("text not found for: " + _ctName + " dummy text set.");
                graveText = "Dummy Text for: " + _ctName;
            }

            _gravestone.SetCanvasText(graveText);

            ///Add body part to grave
            _grave.SetBodyPart(_pt, _ct);
        }
    }


    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyUp(KeyCode.Alpha9))
        {
            Setup();
        }
#endif
    }


}
