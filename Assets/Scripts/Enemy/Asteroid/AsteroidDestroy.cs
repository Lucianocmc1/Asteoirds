using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy
{
public class AsteroidDestroy : EnemyHealt, IDestroy,IEnemyInfo
{
    [SerializeField] GameObject particleDestroy;
    [SerializeField] AudioClip newSfxDestroy;
    [SerializeField] EnemySO newDataEnemy;
    [SerializeField] bool detach;
    DetachAsteroid spawnAsteroid;
    public event EventHandler<EventSpawnEnemy> OnDestroyEnemy;
    
    void Start()
    {
        InitData(newDataEnemy,newSfxDestroy);
        if (detach) spawnAsteroid = FindObjectOfType<DetachAsteroid>();
    }
    public void OnDisable() {   if (spawnAsteroid != null) spawnAsteroid.Death(transform.position, newDataEnemy);}
    public void OnDestroyed(bool forPlayer) { Destroyed(forPlayer); }
   
    public EventHandler<EventSpawnEnemy> EventOnDestroy(  ) { return OnDestroyEnemy; }
    public TypeEnemy GetTypeEnemy() => newDataEnemy.typeEnemy;
 }
}

// el event OnDestroyEnemy se va a ejecutar cuando se desactive ahora vamos a enlazar el OnDestroyEnemy 

//todos los enemigos deberan tener la clase dropear 
/*
 * DropPowerUP // dropeara powers
 * OnDestroyed // para que otros metodos accedan a destroy 
 * DestroyForPlayer // se invoca dentro de destroyed , si el jugador mata al enemigo 
 * y el metodo OnDisable 
 * EventOnDestroy // devuelve el evento EventHandler<EventSpawnEnemy>()  destroyEnemy
 * 
 */