using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStarter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MenuPotion>() != null)
        {
            other.GetComponent<MenuPotion>().OnPotionActivate();
        }
    }

}
