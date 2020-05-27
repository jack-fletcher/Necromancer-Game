using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowContentsOfArrayAsGizmo : MonoBehaviour
{
    /// <summary>
    /// The array to show
    /// </summary>
    [SerializeField] private GameObject[] m_arrayPoints = null;
    
    /// <summary>
    /// Shows contents as an array
    /// </summary>
    private void OnDrawGizmos()
    {
        for (int i = 0; i < m_arrayPoints.Length; i++)
        {

            if (i + 1 < m_arrayPoints.Length)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(m_arrayPoints[i].transform.position, m_arrayPoints[i + 1].transform.position);
            }
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(m_arrayPoints[i].transform.position, 1);
        }
    }
}
