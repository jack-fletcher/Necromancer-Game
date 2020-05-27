using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SnapPoints : MonoBehaviour
{

    /// <summary>
    /// The scale of the objects //TODO remove this
    /// </summary>
    [SerializeField] private Vector3 m_scale = new Vector3(0,0,0);
    /// <summary>
    /// Reference to empty gameobjects for each snap point within the game world
    /// </summary>
    public List<GameObject> m_Snappoints = new List<GameObject>();
    /// <summary>
    /// Reference to the players hands
    /// </summary>
    private Hand[] m_hands;
    /// <summary>
    /// Reference to the character creator
    /// </summary>
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
                        if (CheckForChildren(m_Snappoints[0]) == false)
                        {
                            SetChild(other.gameObject, m_Snappoints[0], Quaternion.Euler(0, 0, 0));
                        }
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
                        if (CheckForChildren(m_Snappoints[5]) == false)
                        {
                            SetChild(other.gameObject, m_Snappoints[5], Quaternion.Euler(3, 11, -2));
                        }
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
                        if (CheckForChildren(m_Snappoints[2]) == false)
                        {
                            SetChild(other.gameObject, m_Snappoints[2], Quaternion.Euler(0, 0, 236));
                        }
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
                        if (CheckForChildren(m_Snappoints[1]) == false)
                        {
                            SetChild(other.gameObject, m_Snappoints[1], Quaternion.Euler(0, 0, 131));
                        }
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

                        if (CheckForChildren(m_Snappoints[3]) == false)
                        {
                            SetChild(other.gameObject, m_Snappoints[3], Quaternion.Euler(0, 0, 7));
                        } 
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

                        if (CheckForChildren(m_Snappoints[4]) == false)
                        {
                            SetChild(other.gameObject, m_Snappoints[4], Quaternion.Euler(0, 0, -3));
                        }
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

    /// <summary>
    /// Clear parts in child GameObjects
    /// </summary>
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
    /// <summary>
    /// Check if object has children
    /// </summary>
    /// <param name="_parent">object to check</param>
    /// <returns></returns>
    private bool CheckForChildren(GameObject _parent)
    {
        ///If parent has children it can't have more
        if (_parent.transform.childCount != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Set object as child of new parent
    /// </summary>
    /// <param name="_child">child that is being reparented</param>
    /// <param name="_newParent"> the new parent</param>
    /// <param name="_rotation">quaternion rotation of object</param>
    private void SetChild(GameObject _child, GameObject _newParent, Quaternion _rotation)
    {
        foreach (Hand hand in m_hands)
        {
            hand.DetachObject(_child);
        }

        //TODO: This should work how it is, but for now this should be set manually to 50,50,50 as that's the normal scale of objects.
        //Will allow this to be set within the editor to make it easier.
        Vector3 scale = m_scale;
       // Vector3 scale = _child.transform.localScale;
        _child.gameObject.transform.SetParent(_newParent.transform);
        _child.gameObject.transform.position = _newParent.transform.position;
        _child.gameObject.transform.rotation = _rotation;
        _child.gameObject.GetComponent<Rigidbody>().useGravity = false;
        _child.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        Destroy(_child.gameObject.GetComponent<Throwable>());
        _child.transform.localScale = scale;
    }
}
