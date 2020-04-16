using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Nav_Type
{
    Start,
    WayPoint,
    End
}

public class NavPoint : MonoBehaviour
{

    public Nav_Type m_type;
    public float[] m_distanceFromStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
