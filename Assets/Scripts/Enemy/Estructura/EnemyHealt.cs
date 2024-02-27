using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealt : MonoBehaviour
{
    protected EnemySO dataEnemy;
    protected ParticleAsteroidPooling particleDestroyed;
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

        if (particleDestroyed != null)
        InstanceParticleDestroy();
        this.gameObject.SetActive(false);
    }

    protected void InstanceParticleDestroy()
    {
      var particle =  particleDestroyed.GetSystemParticle();
      particle.transform.position = transform.position;
    }
    protected void DestroyedForPlayer()
    {
        ScoreManager.Instance.SetScore(dataEnemy.typeEnemy);
        transform.GetComponent<AudioSource>().PlayOneShot(audioDestroyed);
        DropPowerUP();
    }

    protected virtual void InitData(EnemySO newDataEnemy , AudioClip newAudioDestroyed, ParticleAsteroidPooling fvxDestroyed)
    { 
     dataEnemy = newDataEnemy;
     particleDestroyed = fvxDestroyed;
     audioDestroyed = newAudioDestroyed;
    }  
    protected void DropPowerUP( )=> SpawnPowerUP.Singlenton.InstantiatePowerUP(transform.position, dataEnemy.typeEnemy);

}
