using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStarter : MonoBehaviour
{
    /// <summary>
    /// When an object enters the trigger, if its a potion, activate it
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MenuPotion>() != null)
        {
            other.GetComponent<MenuPotion>().OnPotionActivate();
        }
    }

}
