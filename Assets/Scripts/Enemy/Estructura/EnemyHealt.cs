using Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Threading.Tasks;
public class EnemyHealt : MonoBehaviour
{
    protected EnemySO dataEnemy;
    protected ParticleAsteroidPooling particleDestroyed;
    protected AudioClip audioDestroyed;
    protected SpriteRenderer spriteRenderer;
    protected AudioSource audioSource;

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
        {
          InstanceParticleDestroy();
          this.gameObject.SetActive(false);
        }
    }

    protected void InstanceParticleDestroy()
    {
      if (particleDestroyed is null) return;
      var particle =  particleDestroyed.GetSystemParticle();
      particle.transform.position = transform.position;
    }
    protected async void DestroyedForPlayer()
    {
      await DoFlash();
      ScoreManager.Instance.SetScore(dataEnemy.typeEnemy);
      audioSource.PlayOneShot(audioDestroyed);
      DropPowerUP();
      InstanceParticleDestroy();
      this.gameObject.SetActive(false);
    }

    protected async Task DoFlash()
    {
       Color colorOrigin  = Color.white;
       spriteRenderer.color = dataEnemy.colorFlash;
       await Task.Delay(TimeSpan.FromSeconds(dataEnemy.durationFlash));
       spriteRenderer.color = colorOrigin; 
    }

    protected virtual void InitData(EnemySO newDataEnemy, ParticleAsteroidPooling fvxDestroyed, SpriteRenderer spriteRender)
    { 
     dataEnemy = newDataEnemy;
     particleDestroyed = fvxDestroyed;
     spriteRenderer = spriteRender;
    }
    protected virtual void InitAudio(AudioSource audioSource , AudioClip audioClipDestroy)
    {
     this.audioSource = audioSource;  
     audioDestroyed = audioClipDestroy;
    }
    protected void DropPowerUP( )=> SpawnPowerUP.Singlenton.InstantiatePowerUP(transform.position, dataEnemy.typeEnemy);

}
