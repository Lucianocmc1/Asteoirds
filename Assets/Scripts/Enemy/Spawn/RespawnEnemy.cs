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
    [SerializeField] List<GameObject> listEnemiesCurrent;
    [SerializeField] List<GameObject> listEnemiesToAdd;
    [SerializeField] List<GameObject> listPoolingInstancie; 
    [SerializeField] Transform[] Positions;
    [SerializeField] DictionaryPoolingInstance createPoolingEnemys;
    private Dictionary<TypeEnemy, GameObject> dictionaryPoolings;
    public event EventHandler<EventSpawnEnemy> OnSpawnedEnemy;
  
    private static RespawnEnemy instance;
    public static RespawnEnemy Singlenton { get { return instance; } set { } }

    private void Start()
    {
        dictionaryPoolings = createPoolingEnemys.ToDictionary();
        AddEnemyToSpawn();
        // el evento de Waves subscribirse a OnSpawn() y en cada ves que invokes un enimigo invocas el metodo OnSpawn
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
        if( (time + minuteWaitAddEnemy) <= ScoreManager.Instance.GetMinutes() && (listEnemiesToAdd.Count - 1) > 0)
        {
          AddEnemyToSpawn();
        }
            
    }

    void RespawnEnemys()
    {
        Vector2 pointRespawn = Positions[UnityEngine.Random.Range(0, this.Positions.Length)].transform.position;
        var selectPrefabRandom = UnityEngine.Random.Range(0, listEnemiesCurrent.Count -1);
        if (listEnemiesCurrent.Count == 0) AddEnemyToSpawn();
        GameObject pooling = listPoolingInstancie?[selectPrefabRandom];
        GameObject enemyObject = RequestEnemyPooling(pooling);

        Instantiate(enemyObject, pointRespawn, Quaternion.Euler(0f, 0f, 0f));
        OnSpawnEnemy(enemyObject);
    }
    void OnSpawnEnemy(GameObject enemy)=> OnSpawnedEnemy?.Invoke(this, new EventSpawnEnemy(enemy));
     
    void AddEnemyToSpawn()
    {
       var lastEnemy = listEnemiesToAdd.Count - 1;
       var enemy = listEnemiesToAdd[lastEnemy];
       TypeEnemy typeEnemy = enemy.GetComponent<IEnemyInfo>().GetTypeEnemy();
       if (!dictionaryPoolings.ContainsKey(typeEnemy)) return;

       AddPoolingToList(typeEnemy);
       
       listEnemiesCurrent.Add(listEnemiesToAdd[lastEnemy]);
       listEnemiesToAdd.Remove(listEnemiesToAdd[lastEnemy]);
       time += ScoreManager.Instance.GetMinutes();
    }

    /// <summary>
    ///  accese a un gameObject del diccionario atravez del typeEnemy , despues accede a la poolingCorrespondiente del TypeEnemy;
    ///  *los requisito es que exista una pooling del tipo de enemigo *Obligatorio* agregarla al diccionario desde inspector 
    ///  y que cada enemigo implemente, la interfaz IEnemyInfo *
    /// </summary>
    /// <param name="typeEnemy"></param>

    void AddPoolingToList(TypeEnemy typeEnemy)
    {
      var pooling = dictionaryPoolings[typeEnemy];
      pooling = Instantiate(pooling, Vector3.zero, Quaternion.identity);

      listPoolingInstancie.Add(pooling);
      dictionaryPoolings.Remove(typeEnemy);
    }
    
    GameObject RequestEnemyPooling(GameObject pooling) 
    {
      return pooling.GetComponent<IPoolingEnemy>().RequestEnemy();    
    }
 }

}

//instanciar Poolings ? , dado un diccionario le paso un enemigo y tiene que instanciar esa pooling, sabemos que si hay una pooling siempre responderan
// al llamado para instanciar al enemigo, pero como; 