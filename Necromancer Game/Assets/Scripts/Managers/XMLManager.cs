using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.Xml;
using System.IO;

/// <summary>
/// Created using UnifyCommunities Saving and Loading:Data XMLSerializer tutorial http://wiki.unity3d.com/index.php/Saving_and_Loading_Data:_XmlSerializer
/// </summary>
public class XMLManager : MonoBehaviour
{

    /// <summary>
    /// Reference to the singleton
    /// </summary>
    private static XMLManager _instance;

    public static XMLManager Instance { get { return _instance; } }
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
    }

    //public string[] ReadSentenceData(string name, string target)
    //{

    //       XmlDocument _doc = new XmlDocument();
    //        _doc.Load("Assets/Resources/GameText.xml");

    //    string query = string.Format("//*[@id='{0}']//*[@id='{1}']", name, target);
    //    XmlNode _elem = _doc.SelectSingleNode(query);
    //    if (_elem != null)
    //    {
    //        XmlNodeList _nodeList = _elem.ChildNodes;

            
    //        string[] _elemLists = new string[_nodeList.Count];
    //        for (int i = 0; i < _nodeList.Count; i++)
    //        {
    //            _elemLists[i] = _nodeList[i].InnerXml;
    //        }
    //        return _elemLists;
    //    }
    //    else
    //    {
    //        Debug.Log("element could not be found. Is the input name incorrect?");
    //        return null;
    //    }
    //}

    public string[] ReadChildNodeData(string query)
    {
        XmlDocument _doc = new XmlDocument();
        _doc.Load("Assets/Resources/GameText.xml");
        XmlNode _elem = _doc.SelectSingleNode(query);

        if (_elem != null)
        {
            XmlNodeList _nodeList = _elem.ChildNodes;


            string[] _elemLists = new string[_nodeList.Count];
            for (int i = 0; i < _nodeList.Count; i++)
            {
                _elemLists[i] = _nodeList[i].InnerXml;
                Debug.Log(_elemLists[i]);
            }
            return _elemLists;
        }
        else
        {
            Debug.Log("element could not be found. Is the input name incorrect?");
            return null;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query">Takes in an Xpath expression that evaluates to the XML files given structure.</param>
    /// <returns></returns>
    public string ReadSingleNodeData(string query)
    {

        XmlDocument _doc = new XmlDocument();
        _doc.Load("Assets/Resources/GameText.xml");

        XmlNode _elem = _doc.SelectSingleNode(query);
        if (_elem != null)
        {
            return _elem.InnerXml;
        }
        else
        {
            //Debug.Log("element could not be found. Is the input name incorrect? Input was: " + query);
            return null;
        }

    }

}
