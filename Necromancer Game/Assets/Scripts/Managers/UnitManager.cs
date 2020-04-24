using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{

    /// <summary>
    /// Reference to the singleton
    /// </summary>
    private static UnitManager _instance;

    public static UnitManager Instance { get { return _instance; } }
    /// <summary>
    /// A list of all possible enemies
    /// </summary>
    [SerializeField] private GameObject[] m_enemies = null;

    /// <summary>
    /// List of enemy gameobjects to create.
    /// </summary>
    private List<GameObject> m_enemyUnits = new List<GameObject>();
    /// <summary>
    /// How many enemies to spawn.
    /// </summary>
    [SerializeField] private int m_enemiesToSpawn = 0;

    [Tooltip("Is this a boss wave?")]
    [SerializeField] private bool m_isBossWave = false;
    [Tooltip("Character that is the boss")]
    [SerializeField] private GameObject m_bossChar = null;
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
        SetupUnits();

    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.G))
        {
            CreateUnits();
        }
#endif
    }


    /// <summary>
    /// Designates the units to be created
    /// </summary>
    private void SetupUnits()
    {

        if (m_isBossWave)
        {
            ///Add boss mob to the first index so it always spawns at the back - I.E, end/goal point
            m_enemyUnits.Insert(0, m_bossChar);
        }
        for (int i = 0; i < m_enemiesToSpawn; i++)
        {
            int idx = Random.Range(0, m_enemies.Length);

            m_enemyUnits.Add(m_enemies[idx]);
        }



        //CreateUnits();
    }

    private void CreateUnits()
    {
        int counter = 0;
        int length = NavigationManager.Instance.m_navigationPoints.Length;
        foreach (GameObject _unit in m_enemyUnits)
        {
            if(length <= 1)
            {
                length = NavigationManager.Instance.m_navigationPoints.Length;
            }
            counter++;
            length--;
            //Debug: Always spawns at end point
            //GameObject go = Instantiate(_unit, NavigationManager.Instance.m_endPoint.transform.position, Quaternion.identity );

            //set initial point
            GameObject go = Instantiate(_unit, NavigationManager.Instance.m_navigationPoints[length].transform.position, Quaternion.identity);

            string _ctName = go.GetComponent<CharacterStats>().m_characterType.ToString();
            //TODO: Replace 'FriendlyUnits' with 'EnemyUnits' once XML data is filled in.
            go.name = XMLManager.Instance.ReadSingleNodeData($"(//*[@id='FriendlyUnits']//*[@id='{_ctName}']//*[@id='Name'])[{counter}]");
        }
    }
}

