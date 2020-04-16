using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //transform.LookAt(other.gameObject.transform);
        }
    }
}
