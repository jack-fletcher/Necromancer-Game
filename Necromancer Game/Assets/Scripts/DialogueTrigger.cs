using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Derived from Brackeys "How to make a dialogue system in Unity" https://www.youtube.com/watch?v=_nRzoTzeyxU&t=3s
/// </summary>
public class DialogueTrigger : MonoBehaviour
{

    [SerializeField] private Dialogue m_dialogue = null;

    [SerializeField] private Canvas m_canvas = null;

    [SerializeField] private TextMeshProUGUI m_name = null;

    [SerializeField] private TextMeshProUGUI m_content = null;
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

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            TriggerDialogue();
        }
        else
        {
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            DialogueManager.Instance.EndDialogue();
            m_canvas.enabled = false;
        }
    }

    public void TriggerDialogue()
    {
        m_canvas.enabled = true;
        DialogueManager.Instance.StartDialogue(m_dialogue, m_name, m_content);
    }
}
