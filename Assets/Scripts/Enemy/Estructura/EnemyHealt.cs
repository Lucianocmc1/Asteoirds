using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealt : MonoBehaviour
{
    protected EnemySO dataEnemy;
    protected AudioClip audioDestroyed;
    protected void OnCollisionEnter2D(Collision2D other)
    {
        bool player = (other.gameObject.layer == LayerMask.NameToLayer("Player")) || other.gameObject.layer == LayerMask.NameToLayer("BulletPlayer");
        if (player)
        Destroyed(true);
    }
    protected void Destroyed(bool forPlayer)
    {
        if (forPlayer)
         DestroyedForPlayer();
        else
         Debug.LogError("SpawnPowerUP.Singlenton o RespawnEnemy.Singlenton es nulo. Asegúrate de asignar referencias en el Inspector.");

        this.gameObject.SetActive(false);
    }

    protected void DestroyedForPlayer()
    {
        ScoreManager.Instance.SetScore(dataEnemy.typeEnemy);
        transform.GetComponent<AudioSource>().PlayOneShot(audioDestroyed);
        RespawnEnemy.Singlenton.RespawnEnemys();
        DropPowerUP();
        WavesEnemy.Singlenton.RegisterDestroyed(this.gameObject);
    }

    protected virtual void InitData(EnemySO newDataEnemy , AudioClip newAudioDestroyed )
    { 
     dataEnemy = newDataEnemy;
     audioDestroyed = newAudioDestroyed;
    }  
    protected void DropPowerUP( )=> SpawnPowerUP.Singlenton.InstantiatePowerUP(transform.position, dataEnemy.GetLootProbability());

}
