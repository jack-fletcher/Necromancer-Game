using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MenuStartPotion : MenuPotion
{

    /// <summary>
    /// On potion activate, fade to red and transition scene
    /// </summary>
    public override void OnPotionActivate()
    {
        ///Start Scene
        FadeIn(Color.red, 1);
        base.OnPotionActivate();
    } 
}
