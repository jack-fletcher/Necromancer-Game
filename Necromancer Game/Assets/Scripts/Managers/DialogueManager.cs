using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Derived from Brackeys "How to make a dialogue system in Unity" https://www.youtube.com/watch?v=_nRzoTzeyxU&t=3s
/// </summary>
public class DialogueManager : MonoBehaviour
{
    /// <summary>
    /// Reference to the singleton
    /// </summary>
    private static DialogueManager _instance;

    public static DialogueManager Instance { get { return _instance; } }
    /// <summary>
    /// Implementation of singleton - If there's no other static instance in the scene, keep this one. Else, destroy it
    /// </summary>
    private void Awake()
    {
        if (_instance == null || _instance != this)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    public Queue<string> m_sentences = new Queue<string>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartDialogue(Dialogue _dialogue, TextMeshProUGUI _name, TextMeshProUGUI _content)
    {

        m_sentences.Clear();

        _name.text = _dialogue.m_name;
        
        foreach (string sentence in _dialogue.m_sentences)
        {
            m_sentences.Enqueue(sentence);
        }

        DisplayNextSentence(_content);
    }

    public void DisplayNextSentence(TextMeshProUGUI _content)
    {
        if (m_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string _sentence = m_sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(_sentence, _content));
        StartCoroutine(ShowNextSentence(_content));
    }

    IEnumerator TypeSentence(string sentence, TextMeshProUGUI _content)
    {
        _content.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            _content.text += letter;
            yield return null;
        }
    }

    IEnumerator ShowNextSentence(TextMeshProUGUI _content)
    {

        yield return new WaitForSeconds(3f);
        DisplayNextSentence(_content);
    }
    public void EndDialogue()
    {
        m_sentences.Clear();
    }
}
