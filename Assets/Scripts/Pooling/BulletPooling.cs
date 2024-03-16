using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour , IBulletPooling
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> bulletList;
  
    private void AddBulletToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var bullet = Instantiate(bulletPrefab); //instancia laser
            bullet.gameObject.SetActive(false); // lo desactiva no lo elimina
            bulletList.Add(bullet); //lo añade a la lista
            bullet.transform.parent = transform; // vincula los disparos al transform del que tiene el script
        }
    }
    void Start() => AddBulletToPool(poolSize);

    public GameObject RequestLaser()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
           if (!bulletList[i].gameObject.activeSelf) 
            { 
              bulletList[i].gameObject.SetActive(true);
              return bulletList[i];
            }
        }
        AddBulletToPool(1);
        bulletList[ bulletList.Count - 1 ].gameObject.SetActive(true); //añade 1 laser de hacer falta a la lista y lo coloca en lo ultimo
        return bulletList[bulletList.Count - 1]; //me lo retorna el ultimo creado
    }

    public GameObject GetBullet()=> RequestLaser();
}
