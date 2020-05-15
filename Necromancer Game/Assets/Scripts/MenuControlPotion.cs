using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MenuControlPotion : MenuPotion
{
    [SerializeField] private Transform m_destination = null;
    public override void OnPotionActivate()
    {
        //Don't forget - RGB needs to be divided by 255 to get the 0-1 range
        Color purple = new Vector4(0.2f , 0 , 0.6f, 1);
        
        FadeIn(purple, 1);

        StartCoroutine("Move", 1f);
    }

    IEnumerator Move(int time)
    {
        GameObject _playerObject = Player.instance.gameObject;

        _playerObject.GetComponent<CharacterController>().enabled = false;
        yield return new WaitForSeconds(time);

        _playerObject.transform.position = m_destination.position;

        _playerObject.GetComponent<CharacterController>().enabled = true;
    }
}
