using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Inventory : MonoBehaviour
{
    /// <summary>
    /// The GameObject to parent the picked up object to.
    /// </summary>
    [Tooltip("The Transform of the GameObject to parent the pickedup object to.")]
    [SerializeField] private Transform m_inventory = null;
    /// <summary>
    /// The tag to compare against, for pickup. Typically set to pickupable.
    /// </summary>
    [Tooltip("The tag to compare against, for adding an object to your inventory.")]
    [SerializeField] private string m_TagToCompare = null;

    Player m_player;
    Hand[] m_hands;



    private void Start()
    {
       
    }
    /// <summary>
    /// On trigger enter, parent the object to the player to add to its inventory.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        ///Checks if the tag has the correct tag and sanity checks whether the player is actually holding the object.
        foreach (Hand hand in m_hands)
        {
            if (other.tag == m_TagToCompare)
            {
                Debug.Log("Hand and tag found");
                hand.DetachObject(other.gameObject, false);
                other.transform.SetParent(m_inventory);                
            }
            else
            {
                
            }
        }
    }

    private void Awake()
    {
        m_player = Player.instance;
        m_hands = Player.instance.hands;
    }
    /// <summary>
    /// Occurs every frame. Used to scale the 
    /// </summary>
    private void Update()
    {
     
    }

    /// <summary>
    /// Detaches the parent from the object when the player moves it from its inventory. Functionally removes it from the inventory.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == m_TagToCompare)
        {
            other.transform.parent = null;
        }
    }

}
