using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DictionaryGenerics<TKey, TValue>
{
    [SerializeField] List<GenericDataDictionary<TKey, TValue>> dataDictionary;
    public Dictionary<TKey, TValue> ToDictionary()
    {
       Dictionary<TKey, TValue> newDict = new Dictionary<TKey, TValue>();
       foreach (var data in dataDictionary)
       {
         newDict.Add(data.key, data.value);
       }

        return newDict;
    }
}

[Serializable]
public class GenericDataDictionary<TKey, TValue>
{
    public TKey key;
    public TValue value;
}
