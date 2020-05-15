using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TeleportToArea : MonoBehaviour
{
    [SerializeField] private Transform m_destination = null;

    [SerializeField] private bool m_fadeToBlack = true;

    [SerializeField] private bool m_useCanvas = false;

    [SerializeField] private Canvas m_canvas = null;

    private void Start()
    {
        if (m_useCanvas || m_canvas != null)
        {
            m_canvas.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player.instance.gameObject)
        {
            if (m_canvas != null && m_useCanvas == true)
            {
                m_canvas.enabled = true;

            }
            else
            {
                EnterRegion(other.gameObject);
            }
        }
    }


    public void EnterRegion(GameObject target)
    {
        if (m_fadeToBlack)
        {
            ///Start coroutine to fade to black..
            StartCoroutine("FadeOut", target);

        }

    }

    public void EnterRegion()
    {
        StartCoroutine("FadeOut", Player.instance);
    }
    IEnumerator FadeOut(GameObject target)
    {
        SteamVR_Fade.View(Color.black, 1);
        yield return new WaitForSeconds(1f);
        StartCoroutine("FadeIn", target);
    }

    IEnumerator FadeIn(GameObject target)
    {
        if (target.GetComponent<CharacterController>() != null)
        {
            target.GetComponent<CharacterController>().enabled = false;
            target.transform.position = m_destination.position;
            target.GetComponent<CharacterController>().enabled = true;
        }
        yield return new WaitForSeconds(0f);
        SteamVR_Fade.View(Color.clear, 1);
    }
}
