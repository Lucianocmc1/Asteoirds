using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class SpawnPowerUP : MonoBehaviour
{
    [SerializeField] GameObject[] packetPowerUP;
    [Tooltip("Solo necesitas asegurarte de que la suma de los porcentajes sea 100.")]
    [SerializeField] DictionaryGenerics<GameObject, float> dictionaryGenericsPowerUP;
    [SerializeField] DictionaryGenerics<TypeEnemy, float> dictionaryGenericsEnemys;
    Dictionary<GameObject,float> statsDropPowerUP = new Dictionary<GameObject,float>();
    Dictionary<TypeEnemy,float> statsDropEnemy = new Dictionary<TypeEnemy,float>();
    static SpawnPowerUP instance;
    public static SpawnPowerUP Singlenton { get{ return instance; }  private set { } }
    private void Awake()
    {
     instance = (instance == null)? this : null;
     if (instance == null) Destroy(gameObject);
     statsDropEnemy = dictionaryGenericsEnemys.ToDictionary();
     statsDropPowerUP = dictionaryGenericsPowerUP.ToDictionary();
    }

    public void InstantiatePowerUP(Vector3 position, float lootDifficulty)
    {
     bool drop;
     CanDropEnemy(out drop);
     if (!drop) return;
     DropPowerUp(position);
    }

    void CanDropEnemy(out bool drop)
    {
        float randomValue = UnityEngine.Random.Range(0f, 100f);
        float cumulativePercentage = 0f;
        drop = false;
        foreach (var typeDrop in statsDropEnemy)
        {
            cumulativePercentage += typeDrop.Value;
            if (randomValue <= cumulativePercentage)
            drop = true;
        }
    }
    void DropPowerUp(Vector3 position )
    {
      float randomValue = UnityEngine.Random.Range(0f, 100f);
      float cumulativePercentage = 0f;
        
        foreach (var powers in statsDropPowerUP)
        {
            cumulativePercentage += powers.Value;
            if (randomValue <= cumulativePercentage)
            {
                Instantiate(powers.Key, position, Quaternion.identity);
                break;  
            }
        }
    }
}
 
