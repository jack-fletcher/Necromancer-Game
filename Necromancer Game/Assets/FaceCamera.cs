using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{

    private GameObject m_targetCamera;
    private void Start()
    {
        m_targetCamera = Camera.main.gameObject;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(m_targetCamera.transform);
    }
}
