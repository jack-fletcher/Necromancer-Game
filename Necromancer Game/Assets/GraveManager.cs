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
        
        foreach (GameObject go in m_graveSpots)
        {
            Grave _grave = go.GetComponent<Grave>();
            System.Random rand = new System.Random();
            int _idx = rand.Next(0, Enum.GetValues(typeof(Part_Type)).Length);
            Part_Type _pt = (Part_Type)_idx;
            int idx = rand.Next(0, Enum.GetValues(typeof(Class_Type)).Length);
            Class_Type _ct = (Class_Type)_idx;
            ///Set text on grave
            string output = CreateGraveText(_ct);
            _grave.SetCanvasText(output);

            ///Add body part to grave
            GameObject _bodyPart = CreateBodyPart(_pt);
            _grave.SetBodyPart(_bodyPart);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private GameObject CreateBodyPart(Part_Type _pt)
    {
        ///Test/debug
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.AddComponent<BodyPart>();
        cube.AddComponent<Interactable>();
        cube.AddComponent<Throwable>();
        cube.GetComponent<BodyPart>().m_part_Type = _pt;
        return cube;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string CreateGraveText(Class_Type _ct)
    {


        return "debug";
    }
}
