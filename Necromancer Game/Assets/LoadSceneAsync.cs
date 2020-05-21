using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAsync : MonoBehaviour
{
    [SerializeField] private string m_sceneToLoad = null;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync(m_sceneToLoad);    
    }

}
