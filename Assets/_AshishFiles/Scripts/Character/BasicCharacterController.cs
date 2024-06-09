using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Handles Generic movement for all the characters
/// </summary>
public class BasicCharacterController : MonoBehaviour
{
    #region Variables
    protected Transform _targetToAttack;
    protected NavMeshAgent _agent;
    protected Animator _characterAnimator;
    protected int _damage, _health;
    #endregion

    #region Monobehaviour Callbacks
    protected virtual void Awake()
    {
        _targetToAttack = GameObject.Find("EnemyMainCastle").transform; //finds the target to go to
        _agent = GetComponent<NavMeshAgent>();
        _characterAnimator = GetComponent<Animator>();
    }

    protected virtual void OnEnable()
    {
        _agent.SetDestination(_targetToAttack.position);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(_agent.remainingDistance < 3f)
        {
            _agent.speed = 0;
            _characterAnimator.SetBool("Attacking", true);
        }    
    }
    #endregion

    #region Public Methods
    public void InitialiseValues(CharacterData data)
    {
        _damage = data._damage;
        _health = data._health;
        _agent.speed = data._speed;
    }
    public void Damage()
    {
        _targetToAttack.GetComponent<IDamageable>().Damage(_damage);
    }
    #endregion

}
