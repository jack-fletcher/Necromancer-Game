using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] private bool m_isRandomlyGenerated = false;
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
    [SerializeField] private UnitInventory m_unitInventory = null;
    [SerializeField] private GameObject m_spawnPoint = null;

    private GameObject m_enemiesParent = null;
    private GameObject m_friendlyParent = null;
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
            CreateEnemyUnits();
        }
#endif

     //   MediateGame();
    }


    /// <summary>
    /// Designates the units to be created
    /// </summary>
    private void SetupUnits()
    {
        if (m_isRandomlyGenerated == true)
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
        }
        else if (m_isRandomlyGenerated == false)
        {
            ///Do something with predetermined troops
        }


        //CreateUnits();
    }
    public void CreateUnits()
    {
        CreateEnemyUnits();
        CreateFriendlyUnits();
    }
    private void CreateEnemyUnits()
    {
        int counter = 0;
        int length = NavigationManager.Instance.m_navigationPoints.Length;

        m_enemiesParent = new GameObject();
        m_enemiesParent.name = "Enemy Units";
        m_enemiesParent.transform.SetParent(this.transform);
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

            StartCoroutine(Wait(1f));
            GameObject go = Instantiate(_unit, NavigationManager.Instance.m_navigationPoints[length].transform.position, Quaternion.identity);

            string _ctName = go.GetComponent<CharacterStats>().m_characterType.ToString();
            //TODO: Replace 'FriendlyUnits' with 'EnemyUnits' once XML data is filled in. //Done
            go.name = XMLManager.Instance.ReadSingleNodeData($"(//*[@id='EnemyUnits']//*[@id='{_ctName}']//*[@id='Name'])[{counter}]");
            go.transform.SetParent(m_enemiesParent.transform);
        }
    }


    private void CreateFriendlyUnits()
    {
        m_friendlyParent = new GameObject();
        m_friendlyParent.name = "Friendly Units";
        m_friendlyParent.transform.SetParent(this.transform);
        foreach (var item in m_unitInventory.m_units)
        {
            StartCoroutine(Wait(1f));
           GameObject _unit = Instantiate(item, m_spawnPoint.transform.position, Quaternion.identity);

            _unit.transform.SetParent(m_friendlyParent.transform);
        }
    }

    public IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);
    }


    public void MediateGame()
    {
        Debug.Log("Mediating...");
        bool _alliesActive = false;
        foreach (Transform child in m_friendlyParent.transform)
        {
            if (child.gameObject.activeInHierarchy)
            {
                _alliesActive = true;
                break;
            }
        }
        bool _enemiesActive = false;
        foreach (Transform child in m_enemiesParent.transform)
        {

            if (child.gameObject.activeInHierarchy)
            {
                _enemiesActive = true;
                break;
            }
        }

        if (_alliesActive == false)
        {
            EndGameLoss();
        }
        if (_enemiesActive == false)
        {
            EndGameWin();
        }
    }

    private void EndGameWin()
    {
        Debug.Log("Won Game");
    }
    private void EndGameLoss()
    {
        Debug.Log("Lost Game");
        TeleportToArea _tp = GetComponent<TeleportToArea>();
        _tp.EnterRegion();
    }
}

