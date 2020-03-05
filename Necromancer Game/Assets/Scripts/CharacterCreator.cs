using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
    private SnapPoints m_snapPoints;
    private GameObject[] m_points;
    [SerializeField] private GameObject m_knight;
    [SerializeField] private GameObject m_berserker;
    [SerializeField] private GameObject m_thief;

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
            int _highest = m_dict.ElementAt(0).Value;
            string _minionToCreate = m_dict.ElementAt(0).Key;
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
        switch (_minionToCreate)
        {
            case "knight":
               GameObject _knight = Instantiate(m_knight, this.transform);
                if (_knight.GetComponent<CharacterStats>() == null)
                {
                    _knight.AddComponent<CharacterStats>();
                    _knight.GetComponent<CharacterStats>().m_characterType = Character_Type.Knight;
                }
                break;

            case "berserker":
                GameObject _berserker = Instantiate(m_berserker, this.transform);
                if (_berserker.GetComponent<CharacterStats>() == null)
                {
                    _berserker.AddComponent<CharacterStats>();
                    _berserker.GetComponent<CharacterStats>().m_characterType = Character_Type.Berserker;
                }
                break;

            case "thief":

                GameObject _thief = Instantiate(m_thief, this.transform);
                if (_thief.GetComponent<CharacterStats>() == null)
                {
                    _thief.AddComponent<CharacterStats>();
                    _thief.GetComponent<CharacterStats>().m_characterType = Character_Type.Thief;
                }
                break;

            default:

                Debug.LogError("Error failed: minion to create not specified.");
                break;

        }
        m_snapPoints.ClearParts();
        Debug.Log("Minion created");
    }
}
