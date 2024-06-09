using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the Enemy's Castle properties
/// </summary>
public class EnemyCastleManager : MonoBehaviour, IDamageable
{
    #region Variables
    int _castleHealth = 1000;
    #endregion


    #region Monobehaviour Callbacks
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region Public Method
    public void Damage(int damage)
    {
        if(_castleHealth <= 0)
        {
            Debug.Log("Castle Died");
            return;
        }

        _castleHealth -= damage;
        UIManager.Instance.UpdateEnemyHealthText(_castleHealth);
    }
    #endregion
}
