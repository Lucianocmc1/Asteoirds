using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy
{
public class AsteroidDestroy : EnemyHealt, IDestroy,IEnemyInfo
{
    [SerializeField] AudioClip newSfxDestroy;
    [SerializeField] EnemySO newDataEnemy;
    [SerializeField] bool detach;
    DetachAsteroid spawnAsteroid;
    IGetSystemParticle particleDestroy;
    AdapterServiceLocator refence;

    void Start()
    {
      refence = AdapterServiceLocator.Singlenton;
      particleDestroy = refence.GetPoolingParticle(newDataEnemy.typeEnemy);
      var spriteEnemy = transform.GetChild(0);

      InitData(newDataEnemy, particleDestroy, spriteEnemy.GetComponent<SpriteRenderer>());
      if (detach) spawnAsteroid = refence.GetDeatchAsteroid();
    }
    public void OnDisable() {   if (spawnAsteroid != null) spawnAsteroid.Death(transform.position, newDataEnemy);}
    public void OnDestroyed(bool forPlayer) { Destroyed(forPlayer); }
   

    //public EventHandler<EventSpawnEnemy> EventOnDestroy(  ) { return OnDestroyEnemy; }
    public TypeEnemy GetTypeEnemy() => newDataEnemy.typeEnemy;
 }
}
