using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DictionaryPoolingInstance 
{
  [SerializeField] DictionaryPooling[] dictionaryEnemies;

  public Dictionary<TypeEnemy, GameObject> ToDictionary()
  {
     Dictionary<TypeEnemy, GameObject> newDict = new Dictionary<TypeEnemy, GameObject>();
     foreach (var enemy in dictionaryEnemies)
     newDict.Add(enemy.typeEnemy, enemy.poolingInstance);

      return newDict;
  }
 }


[Serializable]
public class DictionaryPooling
{
    public TypeEnemy typeEnemy;
    public GameObject poolingInstance;
}

