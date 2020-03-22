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
    /// Array of sentences to be spoken
    /// </summary>
    [TextArea(3,9)]
    public string[] m_sentences;

}
