using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR.InteractionSystem;

/// <summary>
/// Derived from Brackeys "How to make a dialogue system in Unity" https://www.youtube.com/watch?v=_nRzoTzeyxU&t=3s
/// </summary>
public class DialogueTrigger : MonoBehaviour
{
    /// <summary>
    /// Reference to a specific Dialogue class
    /// </summary>
    [SerializeField] private Dialogue m_dialogue = null;
    /// <summary>
    /// Reference to the canvas the visual sentence will be shown on.
    /// </summary>
    [SerializeField] private Canvas m_canvas = null;
    /// <summary>
    /// GUI showing villager name
    /// </summary>
    [SerializeField] private TextMeshProUGUI m_name = null;
    /// <summary>
    /// GUI Showing sentence data
    /// </summary>
    [SerializeField] private TextMeshProUGUI m_content = null;

    /// <summary>
    /// Reference to the animator attached to GameObject
    /// </summary>
    [SerializeField] private Animator m_anim = null;
        // Start is called before the first frame update
        void Start()
    {
        m_canvas.enabled = false;
        m_dialogue.SetSentences();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// When within close proximity, show text
    /// </summary>
    /// <param name="other"> The GameObject that entered the trigger</param>
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == Player.instance.gameObject)
        {
            m_canvas.enabled = true;
            StartCoroutine("ScaleUp");
        }
        else
        {
        }
    }
    /// <summary>
    /// If a player leaves the proximity, end text
    /// </summary>
    /// <param name="other"> The GameObject that exited the trigger</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player.instance.gameObject)
        {
            DialogueManager.Instance.EndDialogue();
            m_canvas.enabled = false;
        }
    }
    /// <summary>
    /// When Dialogue is triggered, access dialoguemanager singleton to start sentence
    /// </summary>
    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(m_dialogue, m_name, m_content);
    }
    /// <summary>
    /// Starts the scaleUp animation
    /// </summary>
    /// <returns></returns>
    IEnumerator ScaleUp()
    {
        float _animLength = 0;


        m_anim.SetTrigger("ScaleUp");
        AnimationClip[] _animations = m_anim.runtimeAnimatorController.animationClips;

        foreach (var item in _animations)
        {
            if (item.name == "Dialogue_ScaleUp")
            {
                _animLength = item.length;
            }
        }

       // AnimatorClipInfo[] _currentClipInfo = m_anim.GetCurrentAnimatorClipInfo(0);
      //  Debug.Log(_currentClipInfo.Length);
       //_animLength = _currentClipInfo[0].clip.length;

        yield return new WaitForSeconds(0);
            TriggerDialogue();
            Debug.Log("Worked");

    }
}
