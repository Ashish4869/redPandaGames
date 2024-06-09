using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds data for the character
/// </summary>
[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class CharacterData : ScriptableObject 
{
    public int _damage;
    public int _elixirCost;
    public float _speed;
    public int _health;
    public string _prefabTag;
}
