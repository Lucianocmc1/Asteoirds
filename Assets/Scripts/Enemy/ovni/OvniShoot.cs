using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvniShoot : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField,Range(0, 10)] float intervalShoot;
    [SerializeField,Range(0, 10)] float lastShoot;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private AudioClip sfxEnemyShoot;
    [SerializeField] Transform target;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        RandomShootFire();
        target = AdapterServiceLocator.Singlenton.GetService<IShip>().GetTransform();
    }
    
    private void RandomShootFire() { lastShoot += Random.Range(0f, 5f); }
    private void Shooting()
    {
        GameObject bullet = BulletEnemiPooling.Instance.RequestTO(transform.position);
        BulletEnemi componentBullet = bullet.GetComponent<BulletEnemi>();
        componentBullet?.Shoot(transform.position, bulletSpeed + rb.velocity.magnitude, ShootTo());//accedo al pooling de los disparos
        GetComponent<AudioSource>().PlayOneShot(this.sfxEnemyShoot);
        this.lastShoot += Time.time;
        RandomShootFire();
    }
    private void Shoot()
    {
        if ((lastShoot + intervalShoot) <= Time.time) Shooting();
    }
    Vector2 ShootTo() => target.position - transform.position;
    // Update is called once per frame
    void Update()=> Shoot();
  
}

