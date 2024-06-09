using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Hnadles UI related functionality
/// </summary>
public class UIManager : MonoBehaviour
{
    #region Singleton Pattern
    public static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindAnyObjectByType<UIManager>();

                if(_instance == null)
                {
                    _instance = new GameObject().AddComponent<UIManager>();
                }
            }

            return _instance;   
        }
    }
    #endregion
    #region Variables
    TextMeshProUGUI _gemsText;
    TextMeshProUGUI _enemyHealthText;
    #endregion

    #region Monobehaviour Callbacks
    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(_instance);
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


    #region PrivateMethods
    private void InitialiseVariables()
    {
        _enemyHealthText = transform.Find("EnemyCastleHealth/EnemyCastleHealthText").GetComponent<TextMeshProUGUI>();
        _gemsText = transform.Find("ElixirInformation/GemsParent/GemAmount").GetComponent<TextMeshProUGUI>();
        _gemsText.text = GameManager.Instance.GetPresentElixir().ToString(); 
    }

    #endregion

    #region Public Methods
    public void UpdateElixirUI(int value)
    {
        _gemsText.text = value.ToString();
    }

    public void UpdateEnemyHealthText(int value)
    {
        _enemyHealthText.text = value.ToString();
    }
    #endregion

}
