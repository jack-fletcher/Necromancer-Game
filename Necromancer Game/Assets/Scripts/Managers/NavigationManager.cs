using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class NavigationManager : MonoBehaviour
{
    /// <summary>
    /// Reference to the singleton
    /// </summary>
    private static NavigationManager _instance;

    public static NavigationManager Instance { get { return _instance; } }

    public NavPoint m_startPoint;
    public NavPoint m_endPoint;
    /// <summary>
    /// 
    /// </summary>
    [Tooltip("Add all non start/end points here in the order you want them.")]
    public NavPoint[] m_navigationPoints;

    /// <summary>
    /// List of sorted navigation points.
    /// </summary>
    //private List<GameObject> m_navigationPoints;
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
        ///Add all navigation points to the array
        //m_navigationPoints = GameObject.FindGameObjectsWithTag("Navigation").ToList();

    }
    // Start is called before the first frame update
    void Start()
    {
        //SortNavigationPoints();

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    ///Sorts navigation points by distance to start point - Not sure if I want to do this anymore since there may be a path taken that ends up being closer to the start point at a waypoint, which would break it. Probably going to have an editor array that it iterates through.
    /// </summary>
    //private void SortNavigationPoints()
    //{
    //    NavPoint m_startPoint = null;
    //    NavPoint m_endPoint = null;

    //    ///Find the start and end points, then break
    //    for (int i = 0; i < m_navigationPoints.Count; i++)
    //    {
    //        if (m_navigationPoints[i].GetComponent<NavPoint>().m_type == Nav_Type.Start)
    //        {
    //            ///Get the start point
    //            m_startPoint = m_navigationPoints[i].GetComponent<NavPoint>();
    //            ///Then remove it
    //            m_navigationPoints.Remove(m_navigationPoints[i]);
    //        }


    //        if (m_navigationPoints[i].GetComponent<NavPoint>().m_type == Nav_Type.End)
    //        {
    //            ///Get the end point
    //            m_endPoint = m_navigationPoints[i].GetComponent<NavPoint>();
    //            ///Then remove it
    //            m_navigationPoints.Remove(m_navigationPoints[i]);
    //        }
    //            ///Break if both conditions are true
    //        if (m_startPoint != null && m_endPoint != null)
    //        {
    //            break;
    //        }
    //    }
    //}


    void OnDrawGizmos()
    {
        
        for (int i = 0; i < m_navigationPoints.Length; i++)
        {

            if (i + 1 < m_navigationPoints.Length)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(m_navigationPoints[i].transform.position, m_navigationPoints[i + 1].transform.position);
            }
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(m_navigationPoints[i].transform.position, 1);
        }
    }
}

