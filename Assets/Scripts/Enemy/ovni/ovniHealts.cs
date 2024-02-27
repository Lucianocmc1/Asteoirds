using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

namespace Enemy {
    public class ovniHealts : EnemyHealt, IDestroy , IEnemyInfo
    {
    [SerializeField] private ParticleAsteroidPooling particleDestroy;
    [SerializeField] private AudioClip sfxDestroy;
    [SerializeField] EnemySO newDataEnemy;
    [SerializeField] int lifeAmmount;

    EventSpawnEnemy enty;
    public event EventHandler<EventSpawnEnemy> OnDestroyEnemy;
        void Start() 
        {
            enty = new EventSpawnEnemy(this.gameObject);
            InitData(newDataEnemy,sfxDestroy, null);
        } 
    void LowHealt(bool forPlayer)
    {
        lifeAmmount = (lifeAmmount > 0) ?  (lifeAmmount - 1): 0;
        if (lifeAmmount == 0) { Destroyed(forPlayer); }
    }
  
    public void OnDestroyed(bool forPlayer) => LowHealt(forPlayer);
   
    public void OnDisable()
    {
        OnDestroyEnemy?.Invoke(this, enty); // le avisa al wavesEnemy? 
    }
     public TypeEnemy GetTypeEnemy() => newDataEnemy.typeEnemy;
  }
}
