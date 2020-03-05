using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderInfo : MonoBehaviour
{

    private List<Grave> _subscribers = new List<Grave>();
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Subscribe(Grave _subscriber)
    {
        _subscribers.Add(_subscriber);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Weapon>() != null)
        {
            Debug.Log(" Check within collision exit if statement");
            UpdateSubscribers(collision.gameObject.GetComponent<Weapon>().m_damage);
        }
    }

    private void UpdateSubscribers(float damage)
    {
        foreach (Grave _grave in _subscribers)
        {
            _grave.TakeDamage(damage);
        }
    }
}
