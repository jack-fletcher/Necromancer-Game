using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    /// <summary>
    /// Sets the sentence data
    /// </summary>
    public void SetSentences()
    {
        SetHintName();
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
    //This is not a good solution. //TODO change this to be...Not this
    /// <summary>
    /// Sets the hint randomly from the graves on the map
    /// </summary>
    public void SetHintName()
    {

        if (m_dialogueType == Dialogue_Types.Part_Hint)
        {
            //Get a random grave name from the graves within the gravemanager instance, get the first child (the gravestone) then get the first child again (canvas) then get the first child again (tmpro gui) then get the text from that

            int _idx = UnityEngine.Random.Range(0, GraveManager.Instance.m_graveSpots.Length);
            //This should return the full name including filler text, but we can assume the first word is always the characters first name - bad design //TODO change and this should use regex anyways
            string name = GraveManager.Instance.m_graveSpots[_idx].gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
            //Trim leading whitspace 
            name = name.Trim();
            //Get the first name, which should be up til the first space
            name = name.Substring(0, name.IndexOf(" "));
            ///Sanity check
          //  Debug.Log(name);
            ///Search the xml file for something with this first name
            m_hintName = name;
        }
    }
}
