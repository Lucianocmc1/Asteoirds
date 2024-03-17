using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy 
{
    public class ovniHealts : EnemyHealt, IDestroy , IEnemyInfo
    {
    [SerializeField] EnemySO newDataEnemy;
    [SerializeField] int lifeAmmount;
    IGetSystemParticle particleDestroy;
    GameObject poolingInstance;
    AdapterServiceLocator refence;
    
    void Start() 
    {
      refence = AdapterServiceLocator.Singlenton;
      particleDestroy = refence.GetPoolingParticle(newDataEnemy.typeEnemy);
      var spriteEnemy = transform.GetChild(0);

      InitData(newDataEnemy, particleDestroy, spriteEnemy.GetComponent<SpriteRenderer>() );
    } 
    void LowHealt(bool forPlayer)
    {
      lifeAmmount = (lifeAmmount > 0) ?  (lifeAmmount - 1): 0;
      if (lifeAmmount == 0) 
       Destroyed(forPlayer); 
    }
    public void OnDestroyed(bool forPlayer) => LowHealt(forPlayer);
    public TypeEnemy GetTypeEnemy() => newDataEnemy.typeEnemy;
   }

}
