using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateForever : MonoBehaviour
{
    /// <summary>
    /// Speed it rotates per second
    /// </summary>
    [SerializeField] private int m_degreesToRotatePerSecond = 60;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, m_degreesToRotatePerSecond * Time.deltaTime);
    }
}
