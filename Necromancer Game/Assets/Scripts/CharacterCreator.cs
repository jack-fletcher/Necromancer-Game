using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
    private SnapPoints m_snapPoints;
    private GameObject[] m_points;
    [SerializeField] private GameObject m_knight = null;
    [SerializeField] private GameObject m_berserker = null;
    [SerializeField] private GameObject m_thief = null;

    Dictionary<string, int> m_dict = new Dictionary<string, int>();
    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        m_snapPoints = this.GetComponent<SnapPoints>();
        m_points = m_snapPoints.m_Snappoints.ToArray();

        ///Initialise dictionary with every value within the array to a value of 0
        foreach (Class_Type bp in Enum.GetValues(typeof(Class_Type)))
        {
            m_dict.Add(bp.ToString(), 0);
        }
}
/// <summary>
/// 
/// </summary>
public void CheckForParts()
    {
        bool isComplete = false;
        foreach (GameObject point in m_points)
        {
            ///BUG: This only checks if the point has children then checks if the parent has the component. Needs to check if children have component. FIXED: Change to GetComponentInChildren
            if (point.transform.childCount > 0)
            {
                isComplete = true;
                if(point.GetComponentInChildren<BodyPart>() != null)
                {
                    ///Add 1 to m_dicts count of each type of body part
                    m_dict[point.GetComponentInChildren<BodyPart>().m_class_Type.ToString()]++;
                    Debug.Log("Class Type is: " + point.GetComponentInChildren<BodyPart>().m_class_Type.ToString());
                }
            }
            else
            {
                isComplete = false;
                Debug.Log("child not found");
                break;
            }
        }
        if (isComplete == true)
        {
            //Create a minion

            ///Decide its class
            //Default value is the first element of dictionary
            int _highest = m_dict.ElementAt(0).Value;
            ///Therefore the default minion is the first element
            string _minionToCreate = m_dict.ElementAt(0).Key;
            ///Iterate through dictionary to see which has the highest number of calls
            for (int i = 1; i < m_dict.Count; i++)
            {
       

                if (m_dict.ElementAt(i).Value > _highest)
                {
   

                    _highest = m_dict.ElementAt(i).Value;
                    _minionToCreate = m_dict.ElementAt(i).Key;
  
                }
            }


            Debug.Log(_minionToCreate);

            foreach (var idx in m_dict)
            {
                Debug.Log("Dictionary key: " + idx.Key + " with value: " + idx.Value);
            }

            CreateMinion(_minionToCreate);
        }
    }

    private void CreateMinion(string _minionToCreate)
    {
        GameObject _minion = null;
        switch (_minionToCreate)
        {
           
            case "knight":
                _minion = Instantiate(m_knight);
                if (_minion.GetComponent<CharacterStats>() == null)
                {
                    _minion.AddComponent<CharacterStats>();
                    _minion.GetComponent<CharacterStats>().m_characterType =  Class_Type.knight;
                }
                break;

            case "berserker":
                 _minion = Instantiate(m_berserker);
                if (_minion.GetComponent<CharacterStats>() == null)
                {
                    _minion.AddComponent<CharacterStats>();
                    _minion.GetComponent<CharacterStats>().m_characterType = Class_Type.berserker;
                }
                break;

            case "thief":

                _minion = Instantiate(m_thief);
                if (_minion.GetComponent<CharacterStats>() == null)
                {
                  
                    _minion.AddComponent<CharacterStats>();
                    _minion.GetComponent<CharacterStats>().m_characterType = Class_Type.thief;
                }
                break;

            default:

                Debug.LogError("Error failed: minion to create not specified.");
                break;

        }
        _minion.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        m_snapPoints.ClearParts();

        //Not sure if I need to clear the dict, I think so - //TODO check this:
        //foreach (var key in m_dict.Keys.ToList())
        //{
        //    m_dict[key] = 0;
        //}
        Debug.Log("Minion created");
    }
}
