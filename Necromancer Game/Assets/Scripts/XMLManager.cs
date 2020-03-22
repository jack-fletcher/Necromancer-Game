using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Created using UnifyCommunities Saving and Loading:Data XMLSerializer tutorial http://wiki.unity3d.com/index.php/Saving_and_Loading_Data:_XmlSerializer
/// </summary>
public class XMLManager : MonoBehaviour
{

    /// <summary>
    /// Reference to the singleton
    /// </summary>
    private static XMLManager _instance;

    public static XMLManager Instance { get { return _instance; } }
    /// <summary>
    /// Implementation of singleton - If there's no other static instance in the scene, keep this one. Else, destroy it
    /// </summary>
    private void Awake()
    {
        if (_instance == null || _instance != this)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
