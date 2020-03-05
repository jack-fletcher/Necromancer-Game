using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    public void SetCanvasText(string text)
    {
        TextMeshProUGUI _canvasText = GetComponentInChildren<TextMeshProUGUI>();
        _canvasText.text = text;
    }
}
