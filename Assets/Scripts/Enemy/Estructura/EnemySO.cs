using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "ScriptableObject/EnemySO")]
public class EnemySO : ScriptableObject
{
    public TypeEnemy typeEnemy;
    public float speed;
    [SerializeField,Range( 0f, 1f)] float lootDifficulty;
    public float GetLootProbability() => lootDifficulty;
}
