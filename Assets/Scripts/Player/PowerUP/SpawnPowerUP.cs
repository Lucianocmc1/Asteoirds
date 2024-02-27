using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class SpawnPowerUP : MonoBehaviour
{
    [SerializeField] GameObject[] packetPowerUP;
    [Tooltip("Solo Asegurarse de que la suma de los porcentajes sea 100.")]
    [SerializeField] DictionaryGenerics<GameObject, float> dictionaryGenericsPowerUP;
    [Tooltip("El porcentaje maximo es 100.")]
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

    public void InstantiatePowerUP(Vector3 position, TypeEnemy typeEnemy)
    {
      if (!CanDropEnemy(typeEnemy)) return;
      DropPowerUp(position);
    }

    bool CanDropEnemy(TypeEnemy typeEnemy)
    {
      float randomValue = UnityEngine.Random.Range(0f, 100f);
      float dropPercentaje = 0f;
        
      if(statsDropEnemy.TryGetValue(typeEnemy, out float dropProbability))
      dropPercentaje = dropProbability;
      
      return randomValue <= dropPercentaje;
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
 
