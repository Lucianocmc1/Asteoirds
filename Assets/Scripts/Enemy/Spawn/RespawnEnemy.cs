using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
public class RespawnEnemy : MonoBehaviour
{
    int time = 0;
    [SerializeField] int minuteWaitAddEnemy;
    [SerializeField] int secondLastStart;
    [SerializeField] int spawnLastSeconds;
    [SerializeField] int maxEnemy;
    [SerializeField] int ammountEnemy;
    [SerializeField] List<TypeEnemy> listPoolingToAdds;
    [SerializeField] List<GameObject> listPoolingInstancie;  // des Serializar
    [SerializeField] Transform[] pointSpawn;
    private GetRefencie refencie;
    private static RespawnEnemy instance;
    public static RespawnEnemy Singlenton { get { return instance; } set { } }

    private void Start()
    {
      refencie = GetRefencie.Singlenton;
      InvokeRepeating("RespawnEnemys", secondLastStart, UnityEngine.Random.Range(1f, spawnLastSeconds));
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
    private void Update()
    {
        if( (time + minuteWaitAddEnemy) <= ScoreManager.Instance.GetMinutes() && listPoolingToAdds.Count > 0)
        {
          AddEnemyToSpawn();
          time++ ;
        }
    }

    void RespawnEnemys()
    {
       for(int i = 0; i < ammountEnemy; i++)
       { 
        Vector2 pointRespawn = pointSpawn[UnityEngine.Random.Range(0, this.pointSpawn.Length)].transform.position;
        var selectPrefabRandom = UnityEngine.Random.Range(0, listPoolingInstancie.Count);
        GameObject pooling = listPoolingInstancie[selectPrefabRandom];
        GameObject enemy = RequestEnemyPooling(pooling);
        enemy.transform.position = pointRespawn;
       }    
    }
     
    void AddEnemyToSpawn()
    {
      var lastpoolingEnemy = listPoolingToAdds.Count - 1;
      var poolEnemy = listPoolingToAdds[lastpoolingEnemy]; // este me va a dar el ultimo enum añadido 
      var referenciePool = refencie.GetReferencePoolingInstancie(poolEnemy);
      listPoolingInstancie.Add(referenciePool);
      listPoolingToAdds.Remove(poolEnemy);
    }
    /// <summary>
    ///  con el tiempo va agregando poolings a la lista de poolings a utilizar para invocar enemigos;
    /// </summary>
    /// <param name="typeEnemy"></param>

    GameObject RequestEnemyPooling(GameObject pooling)=>   pooling.GetComponent<IPoolingEnemy>().RequestEnemy();    
 }

}
