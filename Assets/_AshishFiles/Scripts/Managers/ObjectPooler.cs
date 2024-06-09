using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Follows Object Pooling design Pattern
/// </summary>

[System.Serializable]
public class PoolItem
{
    public GameObject prefab;
    public int amount;
    public bool expandable;
}
public class ObjectPooler : MonoBehaviour
{
    #region Singleton Pattern Implementation
    public static ObjectPooler _instance;
    
    public static ObjectPooler Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<ObjectPooler>();

                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<ObjectPooler>();
                }
            }
            return _instance;
        }
    }
    #endregion


    #region Variables
    public List<PoolItem> _poolItems;
    public List<GameObject> _pooledItems;
    #endregion

    #region Monobehaviour Callbacks

    public void Awake()
    {
        if(_instance != null)
        {
            Destroy(this);
            return;
        }
        _instance = this;

        InitialisePoolObjects();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region Private Methods
    private void InitialisePoolObjects()
    {
        _pooledItems = new List<GameObject>();

        foreach(PoolItem item in _poolItems)
        {
            for(int i  = 0; i < item.amount; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                _pooledItems.Add(obj);
            }
        }
    }
    #endregion

    #region Public Methods
    public GameObject GetObject(string tag)
    {
        for(int i =0; i < _pooledItems.Count; i++)
        {
            if (!_pooledItems[i].activeInHierarchy && _pooledItems[i].CompareTag(tag))
            {
                return _pooledItems[i];
            }
        }

        foreach(PoolItem item in _poolItems)
        {
            if(item.prefab.tag == tag && item.expandable)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                _pooledItems.Add(obj);
                return obj;
            }
        }

        return null;
    }
    #endregion
}
