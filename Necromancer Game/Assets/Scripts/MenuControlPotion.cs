using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MenuControlPotion : MenuPotion
{
    /// <summary>
    /// Destination within the scene to move character to.
    /// </summary>
    [SerializeField] private Transform m_destination = null;
    /// <summary>
    /// Overriden. When a potion is activated, fade out and move player.
    /// </summary>
    public override void OnPotionActivate()
    {
        //Don't forget - RGB needs to be divided by 255 to get the 0-1 range
        Color purple = new Vector4(0.2f , 0 , 0.6f, 1);
        
        FadeIn(purple, 1);

        StartCoroutine("Move", 1f);
    }

    /// <summary>
    /// Moves the play over time.
    /// </summary>
    /// <param name="time"> Time taken to move player </param>
    /// <returns></returns>
    IEnumerator Move(int time)
    {
        GameObject _playerObject = Player.instance.gameObject;

        _playerObject.GetComponent<CharacterController>().enabled = false;
        yield return new WaitForSeconds(time);

        _playerObject.transform.position = m_destination.position;

        _playerObject.GetComponent<CharacterController>().enabled = true;
    }
}
