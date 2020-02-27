using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Grave : MonoBehaviour
{
    //public TextMeshProUGUI _canvasText;
    /// <summary>
    /// 
    /// </summary>
    private GameObject m_gravestone;
    /// <summary>
    /// 
    /// </summary>
    private GameObject m_grave;
    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        m_gravestone = this.transform.GetChild(0).gameObject;
        m_grave = this.transform.GetChild(1).gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCanvasText(string text)
    {
        TextMeshProUGUI _canvasText = m_gravestone.GetComponentInChildren<TextMeshProUGUI>();
        _canvasText.text = text;
    }

    public void SetBodyPart(GameObject target)
    {
        Instantiate(target, m_grave.transform);
    }
}
