using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SnapPoints : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private List<GameObject> m_Snappoints = new List<GameObject>();
    private Hand[] m_hands;

    private void Awake()
    {
        m_hands = Player.instance.hands;   
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
                            Debug.Log("foreach hand name: " + hand.name);
                            {
                                Vector3 scale = other.transform.localScale;
                                hand.DetachObject(other.gameObject);
                                other.gameObject.transform.SetParent(m_Snappoints[0].transform);
                                other.gameObject.transform.position = m_Snappoints[0].transform.position;
                                other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                                Destroy(other.gameObject.GetComponent<Throwable>());
                                Debug.Log("Moved head");
                                other.transform.localScale = scale;
                            }
                        }
                        break;
                    case Part_Type.torso:
                        foreach (Hand hand in m_hands)
                        {
                            Debug.Log("foreach hand name: " + hand.name);
                            {
                                Vector3 scale = other.transform.localScale;

                                hand.DetachObject(other.gameObject);
                                other.gameObject.transform.SetParent(m_Snappoints[5].transform);
                                other.gameObject.transform.position = m_Snappoints[5].transform.position;
                                other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                                Debug.Log("Moved head");
                                other.transform.localScale = scale;

                            }
                        }
                            break;
                    case Part_Type.left_arm:
                        foreach (Hand hand in m_hands)
                        {
                            Debug.Log("foreach hand name: " + hand.name);
                            {
                                Vector3 scale = other.transform.localScale;

                                hand.DetachObject(other.gameObject);
                                other.gameObject.transform.SetParent(m_Snappoints[2].transform);
                                other.gameObject.transform.position = m_Snappoints[2].transform.position;
                                other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                                Debug.Log("Moved head");
                                other.transform.localScale = scale;

                            }
                        }
                        break;
                    case Part_Type.right_arm:
                        foreach (Hand hand in m_hands)
                        {
                            Debug.Log("foreach hand name: " + hand.name);
                            {
                                Vector3 scale = other.transform.localScale;

                                hand.DetachObject(other.gameObject);
                                other.gameObject.transform.SetParent(m_Snappoints[1].transform);
                                other.gameObject.transform.position = m_Snappoints[1].transform.position;
                                other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                                Debug.Log("Moved head");
                                other.transform.localScale = scale;

                            }
                        }
                        break;
                    case Part_Type.left_leg:
                        foreach (Hand hand in m_hands)
                        {
                            Debug.Log("foreach hand name: " + hand.name);
                            {
                                Vector3 scale = other.transform.localScale;

                                hand.DetachObject(other.gameObject);
                                other.gameObject.transform.SetParent(m_Snappoints[3].transform);
                                other.gameObject.transform.position = m_Snappoints[3].transform.position;
                                other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                                Debug.Log("Moved head");
                                other.transform.localScale = scale;

                            }
                        }
                        break;
                    case Part_Type.right_leg:
                        foreach (Hand hand in m_hands)
                        {
                            Debug.Log("foreach hand name: " + hand.name);
                            {
                                Vector3 scale = other.transform.localScale;

                                hand.DetachObject(other.gameObject);
                                other.gameObject.transform.SetParent(m_Snappoints[4].transform);
                                other.gameObject.transform.position = m_Snappoints[4].transform.position;
                                other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                                Debug.Log("Moved head");
                                other.transform.localScale = scale;

                            }
                        }
                        Debug.Log("right leg for ignored/didnt work");
                        break;

                    default:

                        break;

                     
                }
                Debug.Log(other.GetComponent<BodyPart>().m_part_Type);
            }
        }
      
    }
}
