using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MenuStartPotion : MenuPotion
{


    public override void OnPotionActivate()
    {
        ///Start Scene
        FadeIn(Color.red, 1);
        base.OnPotionActivate();
    } 
}
