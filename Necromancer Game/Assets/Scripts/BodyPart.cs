using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Part_Type
{
    head,
    torso,
    left_arm,
    right_arm,
    left_leg,
    right_leg
   
}
public enum Class_Type
{
    knight, 
    berserker,
    thief
}
public class BodyPart : MonoBehaviour
{
    public Part_Type m_part_Type;
    public Class_Type m_class_Type;

   
}