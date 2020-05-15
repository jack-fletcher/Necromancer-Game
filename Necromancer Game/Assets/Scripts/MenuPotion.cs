using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPotion : MonoBehaviour
{
    [Tooltip("Name of scene to change to if its required")]
    [SerializeField] private string m_nameOfScene = "";

    private void Start()
    {

    }
    public virtual void OnPotionMove()
    {

    }

    public virtual void OnPotionActivate()
    {
        SceneManager.LoadScene(m_nameOfScene);
    }

    public void FadeIn(Color color, int time)
    {
        Valve.VR.SteamVR_Fade.Start(color, time);
        IEnumerator _coroutine = FadeOut(time);
        StartCoroutine(_coroutine);
    }

    public IEnumerator FadeOut(int time)
    {
        yield return new WaitForSeconds(time);
        Valve.VR.SteamVR_Fade.Start(Color.clear, time);

    }
}
