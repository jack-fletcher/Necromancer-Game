using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TeleportToArea : MonoBehaviour
{   
    /// <summary>
    /// Destination transform
    /// </summary>
    [SerializeField] private Transform m_destination = null;
    /// <summary>
    /// Should you fade to black?
    /// </summary>
    [SerializeField] private bool m_fadeToBlack = true;
    /// <summary>
    /// Do you want to show a canvas before teleporting?
    /// </summary>
    [SerializeField] private bool m_useCanvas = false;
    /// <summary>
    /// Reference to a canvas
    /// </summary>
    [SerializeField] private Canvas m_canvas = null;
    /// <summary>
    /// Audio cue
    /// </summary>
    [SerializeField] private AudioSource m_doorSound = null;
    private void Start()
    {
        if (m_useCanvas || m_canvas != null)
        {
            m_canvas.enabled = false;
        }

        if (this.GetComponent<AudioSource>() != null)
        {
            m_doorSound = this.GetComponent<AudioSource>();
        }
    }
    /// <summary>
    /// On trigger enter, if object is player then activate canvas or teleport
    /// </summary>
    /// <param name="other"></param>
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
                if (m_doorSound != null)
                {
                    m_doorSound.Play();
                }
                EnterRegion(other.gameObject);
            }
        }
    }

    /// <summary>
    /// Start coroutine on target
    /// </summary>
    /// <param name="target">Target GameObject</param>
    public void EnterRegion(GameObject target)
    {
        if (m_fadeToBlack)
        {
            ///Start coroutine to fade to black..
            StartCoroutine("FadeOut", target);

        }

    }
    /// <summary>
    /// Start coroutine on player instance
    /// </summary>
    public void EnterRegion()
    {
        StartCoroutine("FadeOut", Player.instance.gameObject);
    }
    /// <summary>
    /// Fades out
    /// </summary>
    /// <param name="target">Target GameObject</param>
    /// <returns></returns>
    IEnumerator FadeOut(GameObject target)
    {
        SteamVR_Fade.View(Color.black, 1);
        yield return new WaitForSeconds(1f);
        StartCoroutine("FadeIn", target);
    }

    /// <summary>
    /// Fades in
    /// </summary>
    /// <param name="target">Target GameObject</param>
    /// <returns></returns>
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
