using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Enemy { 
public class WavesEnemy : MonoBehaviour
{
  [SerializeField] int ammountEnemyWaves;   //cantidad de enemigos que se suman a la siguiente oleada 
  int currentEnemy = 0;   //
  int reaminingEnemy = 0; //enemigos restantes
  int ammountWaves = 0; //cantidad de oleadas
  Dictionary<GameObject, bool> listEnemys = new();
  public EventHandler<EventSpawnEnemy> OndestroyEnemy;
   
  static WavesEnemy instance;
  public static WavesEnemy Singlenton { get { return instance; } private set { } }
   
    void Awake()
    {
        Singlenton = this;
        RespawnEnemy.Singlenton.OnSpawnedEnemy += OnEnemySpawned;
       
    }

    void NextWaves()
    {
        ammountWaves++; //sumo la oleada siguiente
        reaminingEnemy =  ammountEnemyWaves * ammountWaves; // la cantidad de enemigos que tengo que matar se actuliza
    }

    private void Update()
    {
       if (reaminingEnemy == 0) 
       {
         NextWaves(); 
       }
    }
    void DestroyAllEnemys()
    {
      foreach (GameObject gameObject in listEnemys.Keys )
      {
        if( listEnemys.ContainsKey( gameObject) && gameObject.activeSelf == true)
        gameObject.SetActive(false);
      }
    }
    void LessEnemy() => reaminingEnemy--;

    private void OnEnemySpawned(object sender, EventSpawnEnemy spanwEnty) // este es el evento que se comunica con
    {
       currentEnemy++;
       RegisterEnemy(spanwEnty.EntyEnemy);
    }
    
    void RegisterEnemy(GameObject enemy)
    {
        if( !listEnemys.ContainsKey( enemy) )
        listEnemys.Add(enemy, true);
    }

    public void RegisterDestroyed( GameObject enemy)
    {
      if(listEnemys.ContainsKey(enemy))
      { 
       listEnemys[enemy] = false;
       LessEnemy();
      }
    }

   

 }
}

// ahora me queda crear la UI 
/*
 *   se inicia una oleada   (Spawnea  cierta cantidad de enemigos) , 
 *   
 * 
 */