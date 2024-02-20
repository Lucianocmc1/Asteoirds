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
    AudioSource audio;
    float waitTime;

    private void Start()=> audio = GetComponent<AudioSource>(); 

    private void Update()=> ManagerFire();
    
    private void ManagerFire()
    {
        if ( input.OnFire() > 0f && CanShoot()) ShootFire();
    }
    private bool CanShoot() => (Time.time > waitTime);
    private void ShootFire()
    {
        GameObject bullet = BulletPooling.Instance.RequestLaser();
        bullet.GetComponent<Bullet>().Shoot( (Vector2)outBullet.position, (Vector2)transform.position, Quaternion.identity, weapon.speedBullet);
        audio.PlayOneShot(sfxShoot);
        waitTime = Time.time + weapon.cadenceShoot;
    }
}
