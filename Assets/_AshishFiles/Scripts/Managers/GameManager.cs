using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Handles all Game related functionality
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Singleton Pattern
    public static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindAnyObjectByType<GameManager>();
                
                if(_instance == null) _instance = new GameObject().AddComponent<GameManager>();
            }
            return _instance;
        }
    }
    #endregion
    #region Variables
    Transform _enemyCastleTransform;
    EnemyCastleManager _enemyCastleManager;
    int _presentElixir = 10;
    #endregion

    #region Monobehaviour Callbacks
    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(this);
            return;
        }

        _instance = this;
        InitialiseVariables();
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
    private void InitialiseVariables()
    {
        _enemyCastleTransform = GameObject.Find("EnemyMainCastle").transform;
        _enemyCastleManager = _enemyCastleTransform.GetComponent<EnemyCastleManager>();
    }
    #endregion

    #region Public Methods
    public Transform GetEnemyCastleTransform() => _enemyCastleTransform;

    public void SpawnCharacter(CharacterData data, Vector3 posToSpawn)
    {
        if (data._elixirCost <= _presentElixir)
        {
            _presentElixir -= data._elixirCost;
            UIManager.Instance.UpdateElixirUI(_presentElixir);
            GameObject characterObj = ObjectPooler.Instance.GetObject(data._prefabTag);
            characterObj.SetActive(true);
            characterObj.transform.position = posToSpawn;
            characterObj.GetComponent<BasicCharacterController>().InitialiseValues(data);
        }
    }


    public int GetPresentElixir() => _presentElixir;
    #endregion
}
