using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The type of character the entity is.
/// </summary>
public enum Character_Type
{
    Strongman,
    Archer,
    Mage
}
/// <summary>
/// Meant to be inherited from. Shows stats of a character.
/// </summary>
public class CharacterStats : MonoBehaviour
{
        public Character_Type m_characterType;
        
        
}
