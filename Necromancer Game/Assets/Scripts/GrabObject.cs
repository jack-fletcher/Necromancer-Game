using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GrabObject : MonoBehaviour
{
    private Interactable m_interactable;

    // Start is called before the first frame update
    void Start()
    {
        m_interactable = GetComponent<Interactable>();
    }

    private void OnHandHoverBegin(Hand hand)
    {

    }
    
    private void OnHandHoverEnd(Hand hand)
    {

    }

    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes grabtype = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        //Grabbing the object
        if(m_interactable.attachedToHand == null && grabtype != GrabTypes.None)
        {
            hand.AttachObject(gameObject, grabtype);
            hand.HoverLock(m_interactable);
            
        }
        else if (isGrabEnding)
        {
            hand.DetachObject(gameObject);
            hand.HoverUnlock(m_interactable);
        }
    }
}
