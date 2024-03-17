using Enemy;
using System;
using UnityEngine;
using System.Threading.Tasks;

public class EnemyHealt : MonoBehaviour
{
    protected EnemySO dataEnemy;
    protected IGetSystemParticle particleDestroyed;
    protected AudioClip audioDestroyed;
    protected SpriteRenderer spriteRenderer;
    protected void OnCollisionEnter2D(Collision2D other)
    {
        bool player = ((other.gameObject.layer == LayerMask.NameToLayer("Player")) || other.gameObject.layer == LayerMask.NameToLayer("BulletPlayer") || other.gameObject.layer == LayerMask.NameToLayer("Collision Enemy and Bullet"));
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
            PlayAudioDestroy();
            this.gameObject.SetActive(false);
        }
    }

    protected void PlayAudioDestroy()=>  AdapterServiceLocator.Singlenton.PlayAudioDestroy(dataEnemy.soundDestroy, dataEnemy.typeEnemy);
    
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
      PlayAudioDestroy();
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

    protected virtual void InitData(EnemySO newDataEnemy, IGetSystemParticle fvxDestroyed, SpriteRenderer spriteRender)
    { 
     dataEnemy = newDataEnemy;
     particleDestroyed = fvxDestroyed;
     spriteRenderer = spriteRender;
    }
   
    protected void DropPowerUP( )=> SpawnPowerUP.Singlenton.InstantiatePowerUP(transform.position, dataEnemy.typeEnemy);

}
