using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet: MonoBehaviour
{
    float speed;
    Vector2 direction;
    public void Shoot(Vector2 positionOut, Vector2 player,Quaternion rotation ,float speed )
    {
        transform.position = positionOut;
        transform.rotation = rotation;
        StartCoroutine(BulletMovement());
        direction = positionOut - player;
        this.speed = speed;
    }

    private IEnumerator BulletMovement()
    {
        while (gameObject.activeSelf)
        {
            this.transform.Translate( direction * (Time.deltaTime * speed), Space.Self);
            yield return null;
        }
    }

    void Destroyed()=>  gameObject.SetActive(false);
    private void OnTriggerEnter2D(Collider2D other)
    {
        var objects = other.gameObject.GetComponent<IDestroy>();
        objects?.OnDestroyed(true);

       Destroyed();
    }
}
