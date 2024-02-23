using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class DictionaryGenerics<T> 
{
    [SerializeField] GenericDataDictionary<Dictionary<T,T>> dataDictionary;
    public Dictionary<T,T> ToDictionary()
    {
        Dictionary<T, T> newDict = new Dictionary<T, T>();
        foreach ( var x in dataDictionary)
        {
           
        
        }
       
        foreach (var enemy in dictionaryEnemies)
        {
            newDict.Add(enemy.typeEnemy, enemy.score);
        }

        return newDict;
    }
}

[SerializeField]
public class GenericDataDictionary<T>
{
    public T key;
    public T value;
}
