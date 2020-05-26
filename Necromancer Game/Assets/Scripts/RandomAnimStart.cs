using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimStart : MonoBehaviour
{
    /// <summary>
    /// Animator state to play
    /// </summary>
    [SerializeField] private string m_animState = "";

    // Start is called before the first frame update
    void Start()
    {
        Animator _anim = GetComponent<Animator>();
        _anim.Play(m_animState, -1, Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
