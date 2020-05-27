using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Created using Jimmy Vegas 'How to rotate the skybox in realtime' https://www.youtube.com/watch?v=cqGq__JjhMM
/// </summary>
public class SkyboxRotation : MonoBehaviour
{
    /// <summary>
    /// Speed that is used to rotate skybox
    /// </summary>
    [SerializeField] private float m_rotationSpeed = 1.2f;


    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * m_rotationSpeed);
    }
}
