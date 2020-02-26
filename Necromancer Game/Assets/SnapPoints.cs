using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SnapPoints : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public List<GameObject> m_Snappoints = new List<GameObject>();
    private Hand[] m_hands;
    private CharacterCreator m_cc;
    private void Awake()
    {
        m_hands = Player.instance.hands;
        m_cc = this.GetComponent<CharacterCreator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject go in m_Snappoints)
        {
            if (other.GetComponent<BodyPart>() != null)
            {
                other.GetComponent<Interactable>().enabled = false;
                switch (other.GetComponent<BodyPart>().m_part_Type)
                {
                    case Part_Type.head:
                        foreach (Hand hand in m_hands)
                        {
                            hand.DetachObject(other.gameObject);
                        }
                                Vector3 scale = other.transform.localScale;                           
                                other.gameObject.transform.SetParent(m_Snappoints[0].transform);
                                other.gameObject.transform.position = m_Snappoints[0].transform.position;
                                other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                                Destroy(other.gameObject.GetComponent<Throwable>());
                                other.transform.localScale = scale;                          
                        
                        break;
                    case Part_Type.torso:
                        foreach (Hand hand in m_hands)
                        {
                            hand.DetachObject(other.gameObject);
                        }
                                scale = other.transform.localScale;
                                other.gameObject.transform.SetParent(m_Snappoints[5].transform);
                                other.gameObject.transform.position = m_Snappoints[5].transform.position;
                                other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                                other.transform.localScale = scale;
                        
                            break;
                    case Part_Type.left_arm:
                        foreach (Hand hand in m_hands)
                        {
                            hand.DetachObject(other.gameObject);
                        }
                                scale = other.transform.localScale;
                                other.gameObject.transform.SetParent(m_Snappoints[2].transform);
                                other.gameObject.transform.position = m_Snappoints[2].transform.position;
                                other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                                other.transform.localScale = scale;
                        
                        break;
                    case Part_Type.right_arm:
                        foreach (Hand hand in m_hands)
                        {
                            hand.DetachObject(other.gameObject);
                        }
                                scale = other.transform.localScale;
                                other.gameObject.transform.SetParent(m_Snappoints[1].transform);
                                other.gameObject.transform.position = m_Snappoints[1].transform.position;
                                other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                                other.transform.localScale = scale;

                            
                        
                        break;
                    case Part_Type.left_leg:
                        foreach (Hand hand in m_hands)
                        {
                            hand.DetachObject(other.gameObject);
                        }
                                scale = other.transform.localScale;
                                other.gameObject.transform.SetParent(m_Snappoints[3].transform);
                                other.gameObject.transform.position = m_Snappoints[3].transform.position;
                                other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                                other.transform.localScale = scale;
                        break;
                    case Part_Type.right_leg:
                        foreach (Hand hand in m_hands)
                        {
                            hand.DetachObject(other.gameObject);
                        }
                                scale = other.transform.localScale;
                                other.gameObject.transform.SetParent(m_Snappoints[4].transform);
                                other.gameObject.transform.position = m_Snappoints[4].transform.position;
                                other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                                other.transform.localScale = scale;

                        break;

                    default:

                        break;

                     
                }
            }
        }
      //  m_cc.CheckForParts();

    }


    public void ClearParts()
    {
        foreach (GameObject go in m_Snappoints)
        {
            foreach (Transform child in go.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
