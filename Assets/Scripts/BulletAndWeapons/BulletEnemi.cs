using System.Collections;
using UnityEngine;

public class BulletEnemi : MonoBehaviour, IDestroy, IBulletBeheviour
{
    private Vector2 direction;
    public void Shoot(Vector2 from, float speed, Vector2 playerPosition)
    {
        transform.position = from;  //toma la posicon del ovni y empieza la corrutina
        direction =  playerPosition - from; //obtiene la direccion
        StartCoroutine(BulletMovement(speed,direction));
    }

    private IEnumerator BulletMovement(float bulletSpeed,Vector2 direction)
    {
        while (gameObject.activeSelf) //mientras el objeto este activo
        {   
            this.transform.Translate( direction.normalized * (Time.deltaTime * bulletSpeed), Space.Self);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bool player = other.gameObject.layer == LayerMask.NameToLayer("Player");
        if (player)
        {
           other.gameObject.GetComponent<IDestroy>()?.OnDestroyed(true);
           gameObject.SetActive(false);
        }
        else
        {
            Destroyed();
        }

    }
    void Destroyed()=> gameObject.SetActive(false);

    public void OnDestroyed(bool forPlayer) => Destroyed();
}
