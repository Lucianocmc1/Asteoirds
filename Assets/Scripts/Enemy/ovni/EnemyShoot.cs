using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] EnemySO dataEnemy;
    [SerializeField] Rigidbody2D rb;
    [SerializeField, Range(0, 10)] float intervalShoot;
    [SerializeField, Range(0, 10)] float lastShoot;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private AudioClip sfxEnemyShoot;
    [SerializeField] AudioSource audioSource;
    Transform target;
    void Awake()
    {
        rb = (rb is null) ? GetComponent<Rigidbody2D>() : rb;
        audioSource = (audioSource is null) ? GetComponent<AudioSource>() : audioSource;
        RandomShootFire();

    }
    private void OnEnable() => target = AdapterServiceLocator.Singlenton.GetService<IShip>().GetTransform();


    private void RandomShootFire() { lastShoot += Random.Range(0f, 5f); }
    private void Shooting()
    {
        GameObject bullet = AdapterServiceLocator.Singlenton.GetBullet(dataEnemy.typeEnemy);
        bullet.transform.position = transform.position;
        IBulletBeheviour componentBullet = bullet.GetComponent<IBulletBeheviour>();
        componentBullet?.Shoot(transform.position, bulletSpeed + rb.velocity.magnitude, ShootTo());
        audioSource.PlayOneShot(this.sfxEnemyShoot);
        this.lastShoot += Time.time;
        RandomShootFire();
    }
    private void Shoot()
    {
        if ((lastShoot + intervalShoot) <= Time.time) Shooting();
    }
    Vector2 ShootTo()
    {
        target = (target is null) ? AdapterServiceLocator.Singlenton.GetService<IShip>().GetTransform() : target;
        return target.position - transform.position;
    }
    // Update is called once per frame
    void Update() => Shoot();

 }

