using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeEnemyInfo : MonoBehaviour
{
    [SerializeField] EnemySO dataEnemy;
    public TypeEnemy GetTypeEnemy()=> dataEnemy.typeEnemy;
}
