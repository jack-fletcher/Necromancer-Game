using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPotion : MonoBehaviour
{
    [Tooltip("Name of scene to change to if its required")]
    ///
    /// Name of scene to transition to
    /// 
    [SerializeField] private string m_nameOfScene = "";

    private void Start()
    {

    }
    /// <summary>
    /// When potion is moved, do this
    /// </summary>
    public virtual void OnPotionMove()
    {

    }
    /// <summary>
    /// When a potion is activated, do this
    /// </summary>
    public virtual void OnPotionActivate()
    {
        
       StartCoroutine(LoadScene());
    }

    /// <summary>
    /// Fades the screen to a specified colour over time
    /// </summary>
    /// <param name="color">Colour to fade to</param>
    /// <param name="time"> Time it takes to fade</param>
    public void FadeIn(Color color, int time)
    {
        Valve.VR.SteamVR_Fade.Start(color, time);
        IEnumerator _coroutine = FadeOut(time);
        StartCoroutine(_coroutine);
    }

    /// <summary>
    /// Clears the colour of faded screen over time
    /// </summary>
    /// <param name="time"> Time it takes to fade out</param>
    /// <returns></returns>
    public IEnumerator FadeOut(int time)
    {
        yield return new WaitForSeconds(time);
        Valve.VR.SteamVR_Fade.Start(Color.clear, time);

    }

    /// <summary>
    /// Loads scene asyncronously
    /// </summary>
    /// <returns></returns>
    public IEnumerator LoadScene()
    {
        AsyncOperation _asyncLoad = SceneManager.LoadSceneAsync(m_nameOfScene);

        while (!_asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
