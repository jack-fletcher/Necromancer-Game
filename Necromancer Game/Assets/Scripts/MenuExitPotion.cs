using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuExitPotion : MenuPotion
{
    /// <summary>
    /// Quit application
    /// </summary>
    public override void OnPotionActivate()
    {


        Application.Quit();
#if UNITY_EDITOR
        Debug.Log("Application Quit");
#endif
    }
}
