using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] InputPC input;
    [SerializeField] AudioClip sfxShoot;
    [SerializeField] Transform outBullet;
    [SerializeField] float cadenceShoot;
    [SerializeField] WeaponSO weapon;
    [SerializeField] BulletPooling bulletPooling;
    new AudioSource audio;
    Rigidbody2D body;
    float waitTime;
    private void Start()
    { 
        audio = GetComponent<AudioSource>(); 
        body = GetComponent<Rigidbody2D>();
    }
    private void Update()=> ManagerFire();
    private void ManagerFire()
    {
        if ( input.OnFire() > 0f && CanShoot()) ShootFire();
    }
    private bool CanShoot() => (Time.time > waitTime);
    private void ShootFire()
    {
        GameObject bullet = bulletPooling.GetBullet();
        bullet.GetComponent<Bullet>().Shoot( (Vector2)outBullet.position, (Vector2)transform.position, body.velocity.magnitude);
        audio.PlayOneShot(sfxShoot);
        waitTime = Time.time + weapon.cadenceShoot;
    }
    public void SetBulletPoolig(BulletPooling bullet) => bulletPooling = bullet; 
}
