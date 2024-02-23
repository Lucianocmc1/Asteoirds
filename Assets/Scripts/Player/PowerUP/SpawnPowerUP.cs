using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms;

public class SpawnPowerUP : MonoBehaviour
{
    [Tooltip("Maximo 10 powerUPs sino cambiar formula estadistica")]
    [SerializeField] GameObject[] packetPowerUP;

    static SpawnPowerUP instance;
    public static SpawnPowerUP Singlenton { get{ return instance; }  private set { } }
    private void Awake()
    {
        instance = (instance == null)? this : null;
        if (instance == null) Destroy(gameObject);
    }

    public void InstantiatePowerUP(Vector3 position, float lootDifficulty)
    {
      var maxRange = 10f;
      var probabiltySpawnEnemy = UnityEngine.Random.Range(0, maxRange) > (maxRange * lootDifficulty);
      if (probabiltySpawnEnemy)
      {
        var probabilyPower = UnityEngine.Random.Range(0, packetPowerUP.Length * 10) ; 
        switch( probabilyPower)
        {
           
        }

       Instantiate(packetPowerUP[UnityEngine.Random.Range(0, packetPowerUP.Length)], position, Quaternion.identity);
      }
      
    }

  
}
