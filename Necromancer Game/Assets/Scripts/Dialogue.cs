using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived from Brackeys "How to make a dialogue system in Unity" https://www.youtube.com/watch?v=_nRzoTzeyxU&t=3s
/// </summary>
[System.Serializable]
public class Dialogue
{
    /// <summary>
    /// Name of the npc you're conversing with
    /// </summary>
    public string m_name; 
    /// <summary>
    /// The name of the hint to search for within the XML file. //TODO: Change this to be dynamic
    /// </summary>
    [Tooltip("The name of the node the XML file is being searched for.")]
    public string m_hintName;
    /// <summary>
    /// Array of sentences to be spoken
    /// </summary>
    [TextArea(3,9)]
    public string[] m_sentences;

    /// <summary>
    /// The type of dialogue given
    /// </summary>
    [Tooltip("Defines which type of dialogue the character gives.")]
    public Dialogue_Types m_dialogueType;


    public void SetSentences()
    {
        //m_sentences = XMLManager.Instance.ReadSentenceData(m_name, "Hints");

        if (m_dialogueType == Dialogue_Types.Part_Hint)
        {
            m_sentences = XMLManager.Instance.ReadChildNodeData($"//*[@id='FriendlyUnits']//*[@id='{m_hintName}']//*[@id='Hints']");
        }
        else if (m_dialogueType == Dialogue_Types.Defender_Hint)
        {
            m_sentences = XMLManager.Instance.ReadChildNodeData($"//*[@id='EnemyUnits']//*[@id='{m_hintName}']//*[@id='Hints']");

        }
        else
        {
            Debug.LogError("Dialogue type not correct: Output was: " + m_dialogueType.ToString());
        }
    }
}
