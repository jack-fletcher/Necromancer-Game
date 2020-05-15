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

                        DoThing(other.gameObject, m_Snappoints[0], Quaternion.Euler(0, 0, 0));
                        //foreach (Hand hand in m_hands)
                        //{
                        //    hand.DetachObject(other.gameObject);
                        //}
                        //        Vector3 scale = other.transform.localScale;                           
                        //        other.gameObject.transform.SetParent(m_Snappoints[0].transform);
                        //        other.gameObject.transform.position = m_Snappoints[0].transform.position;
                        //        other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                        //        other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                        //        other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                        //        Destroy(other.gameObject.GetComponent<Throwable>());
                        //        other.transform.localScale = scale;                          
                        
                        break;
                    case Part_Type.torso:
                        DoThing(other.gameObject, m_Snappoints[5], Quaternion.Euler(3, 11, -2));
                        //foreach (Hand hand in m_hands)
                        //{
                        //    hand.DetachObject(other.gameObject);
                        //}
                        //        scale = other.transform.localScale;
                        //        other.gameObject.transform.SetParent(m_Snappoints[5].transform);
                        //        other.gameObject.transform.position = m_Snappoints[5].transform.position;
                        //        other.gameObject.transform.rotation = Quaternion.Euler(3, 11, -2);
                        //other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                        //other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                        //Destroy(other.gameObject.GetComponent<Throwable>());
                        //other.transform.localScale = scale;
                        
                            break;
                    case Part_Type.left_arm:
                        DoThing(other.gameObject, m_Snappoints[2], Quaternion.Euler(0, 0, 236));
                        //foreach (Hand hand in m_hands)
                        //{
                        //    hand.DetachObject(other.gameObject);
                        //}
                        //        scale = other.transform.localScale;
                        //        other.gameObject.transform.SetParent(m_Snappoints[2].transform);
                        //        other.gameObject.transform.position = m_Snappoints[2].transform.position;
                        //        other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 131);
                        //other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                        //other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                        //Destroy(other.gameObject.GetComponent<Throwable>());
                        //other.transform.localScale = scale;
                        
                        break;
                    case Part_Type.right_arm:
                        DoThing(other.gameObject, m_Snappoints[1], Quaternion.Euler(0, 0, 131));
                        //foreach (Hand hand in m_hands)
                        //{
                        //    hand.DetachObject(other.gameObject);
                        //}
                        //        scale = other.transform.localScale;
                        //        other.gameObject.transform.SetParent(m_Snappoints[1].transform);
                        //        other.gameObject.transform.position = m_Snappoints[1].transform.position;
                        //        other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                        //other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                        //other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                        //Destroy(other.gameObject.GetComponent<Throwable>());
                        //other.transform.localScale = scale;

                            
                        
                        break;
                    case Part_Type.left_leg:
                        DoThing(other.gameObject, m_Snappoints[3], Quaternion.Euler(0, 0, 7));
                        //foreach (Hand hand in m_hands)
                        //{
                        //    hand.DetachObject(other.gameObject);
                        //}
                        //        scale = other.transform.localScale;
                        //        other.gameObject.transform.SetParent(m_Snappoints[3].transform);
                        //        other.gameObject.transform.position = m_Snappoints[3].transform.position;
                        //        other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                        //other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                        //other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                        //Destroy(other.gameObject.GetComponent<Throwable>());
                        //other.transform.localScale = scale;
                        break;
                    case Part_Type.right_leg:

                        DoThing(other.gameObject, m_Snappoints[4], Quaternion.Euler(0, 0, -3));
                        //foreach (Hand hand in m_hands)
                        //{
                        //    hand.DetachObject(other.gameObject);
                        //}
                        //        scale = other.transform.localScale;
                        //        other.gameObject.transform.SetParent(m_Snappoints[4].transform);
                        //        other.gameObject.transform.position = m_Snappoints[4].transform.position;
                        //        other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                        //other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                        //other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                        //Destroy(other.gameObject.GetComponent<Throwable>());
                        //other.transform.localScale = scale;
                        break;

                    default:

                        break; 
                }
            }
        }
        ///So I can debug these things without needing to go into VR
#if UNITY_EDITOR
       // m_cc.CheckForParts();
#endif
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

    private void DoThing(GameObject _child, GameObject _newParent, Quaternion _rotation)
    {
        foreach (Hand hand in m_hands)
        {
            hand.DetachObject(_child);
        }
        Vector3 scale = _child.transform.localScale;
        _child.gameObject.transform.SetParent(_newParent.transform);
        _child.gameObject.transform.position = _newParent.transform.position;
        _child.gameObject.transform.rotation = _rotation;
        _child.gameObject.GetComponent<Rigidbody>().useGravity = false;
        _child.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        Destroy(_child.gameObject.GetComponent<Throwable>());
        _child.transform.localScale = scale;
    }
}
