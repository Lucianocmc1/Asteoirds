using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class createEnemyDictionary
{
    [SerializeField] DictionaryEnemy[] dictionaryEnemies;

    public Dictionary<TypeEnemy, int> ToDictionary()
    {
       Dictionary<TypeEnemy, int> newDict = new Dictionary<TypeEnemy, int>();
       foreach (var enemy in dictionaryEnemies)
       {
                newDict.Add( enemy.typeEnemy, enemy.score);
       }

        return newDict;
    } 
}


[Serializable]
public class DictionaryEnemy 
{
    public TypeEnemy typeEnemy;
    public int score;
}
