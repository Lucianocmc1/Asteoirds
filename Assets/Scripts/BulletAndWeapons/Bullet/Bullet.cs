using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet: MonoBehaviour
{
    [SerializeField] BulletSO bulletData;
    float speed;
    Vector2 direction;
    public void Shoot(Vector2 positionOut, Vector2 player,float speedShip)
    {
        transform.position = positionOut;
        StartCoroutine(BulletMovement());
        direction = positionOut - player;
        speed = bulletData.speed + speedShip;
    }

    private IEnumerator BulletMovement()
    {
        while (gameObject.activeSelf)
        {
            transform.Translate( direction * (Time.deltaTime * speed), Space.Self);
            Quaternion.LookRotation(-transform.forward);
            yield return null;
        }
    }

    void Destroyed()=>  gameObject.SetActive(false);
    private void OnTriggerEnter2D(Collider2D other)
    {
        var objects = other.gameObject.GetComponent<IDestroy>();
        objects?.OnDestroyed(true);

        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
       Destroyed();
    }
}
