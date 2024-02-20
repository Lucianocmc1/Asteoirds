using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UIElements;

namespace Enemy
{
    public class RespawnEnemy : MonoBehaviour
{
    [SerializeField] WavesEnemy wavesEnemy;
    [SerializeField] Transform[] Positions;
    [SerializeField] int maxEnemy;
    [SerializeField] int ammountEnemy;
    public event EventHandler<EventSpawnEnemy> OnSpawnedEnemy;
    private static RespawnEnemy instance;
    public static RespawnEnemy Singlenton { get { return instance; } set { } }

    private void Start()
    {
        // el evento de Waves subscribirse a OnSpawn() y en cada ves que invokes un enimigo invocas el metodo OnSpawn
        SpawnEnemy(ammountEnemy);
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    public void RespawnEnemys()
    {
        Vector2 pointRespawn = Positions[UnityEngine.Random.Range(0, this.Positions.Length)].transform.position;
        var selectPrefabRandom = UnityEngine.Random.Range(0, maxEnemy);
        GameObject enemyObject;
        switch (selectPrefabRandom)
        {
            case 0:
                enemyObject = Instantiate(AsteroidPooling.Instance.RequestAsteroid(), pointRespawn, Quaternion.Euler(0f, 0f, 0f));
                break;
            case 1:
                enemyObject = Instantiate(OvniPooling.Instance.RequestOvni(), pointRespawn, Quaternion.Euler(0f, 0f, 0f));
                break;
            default:
                enemyObject = Instantiate(AsteroidPooling.Instance.RequestAsteroid(), pointRespawn, Quaternion.Euler(0f, 0f, 0f));
                break;
        }

        OnSpawnEnemy(enemyObject);
    }

    void SpawnEnemy(int amount)
    {
        for (int i = ammountEnemy; i > 0; i--)
        RespawnEnemys();
    }
    void OnSpawnEnemy(GameObject enemy)=> OnSpawnedEnemy?.Invoke(this, new EventSpawnEnemy(enemy));
     
    
       
    //poner el invoke aca=
 }

}
