using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Attack_Type
{
    /// <summary>
    /// Damage from a physical source, e.g sword or arrow.
    /// </summary>
    Physical,
    /// <summary>
    /// Damage from a magical source, e.g wand or staff.
    /// </summary>
    Magical,
    /// <summary>
    /// A subsection of magic, dealing fire damage.
    /// </summary>
    Fire,
    /// <summary>
    /// A subsection of magic, dealing water damage.
    /// </summary>
    Water,
    /// <summary>
    /// A subsection of magic, dealing earth damage.
    /// </summary>
    Earth,
    /// <summary>
    /// A subsection of magic, dealing air damage.
    /// </summary>
    Air,
    /// <summary>
    /// Damage given to the character via the world, e.g fall damage or world fires. Equivalent to 'True damage' where there's no resistance for this.
    /// </summary>
    World
}

/// <summary>
/// Types of dialogue that a villager can have
/// </summary>
public enum Dialogue_Types
{
    Part_Hint,
    Defender_Hint
}
/// <summary>
/// Types of body parts
/// </summary>
public enum Part_Type
{
    head,
    torso,
    left_arm,
    right_arm,
    left_leg,
    right_leg

}
/// <summary>
/// Class types
/// </summary>
public enum Class_Type
{
    knight,
    berserker,
    thief
}
/// <summary>
/// Valid times of day
/// </summary>
public enum TimeOfDay
{
    day,
    night
}
public class Enums : MonoBehaviour
{
}
