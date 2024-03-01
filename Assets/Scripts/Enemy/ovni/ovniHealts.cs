using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy 
{
    public class ovniHealts : EnemyHealt, IDestroy , IEnemyInfo
    {
    [SerializeField] AudioClip sfxDestroy;
    [SerializeField] EnemySO newDataEnemy;
    [SerializeField] int lifeAmmount;
    IGetSystemParticle particleDestroy;
    GameObject poolingInstance;
    GetRefencie refence;
    
    void Start() 
    {
      refence = GetRefencie.Singlenton;
      particleDestroy = refence.GetReferenceParticle(newDataEnemy.typeEnemy);
      var spriteEnemy = transform.GetChild(0);

      InitData(newDataEnemy, particleDestroy, spriteEnemy.GetComponent<SpriteRenderer>() );
      InitAudio(GetComponent<AudioSource>(), sfxDestroy);
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
