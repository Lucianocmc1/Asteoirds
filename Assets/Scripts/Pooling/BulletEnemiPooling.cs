using System.Collections.Generic;
using UnityEngine;

public class BulletEnemiPooling : MonoBehaviour
{
    [SerializeField] private GameObject LaserPrefab;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> laserList;

    private static BulletEnemiPooling instance;
    public static BulletEnemiPooling Instance{ get { return  instance; } }   // lo podremos llammar desde otros scripts

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
        }
        else
        {
            Destroy(gameObject);
        }  
    }
    void Start()=> AddLasersToPool(poolSize);

    private void AddLasersToPool(int amount) 
    {
        for (int i = 0; i < amount; i++)
        {
            var laser = Instantiate(LaserPrefab); //instancia laser
            laser.gameObject.SetActive(false); // lo desactiva no lo elimina
            laserList.Add(laser); //lo añade a la lista
            laser.transform.parent = transform; // vincula los disparos al transform del que tiene el script
        }
    }

    public GameObject RequestLaser()
    {
        for (int i = 0; i < laserList.Count; i++)
        {
           if (!laserList[i].gameObject.activeSelf) 
            { 
              laserList[i].gameObject.SetActive(true);
              return laserList[i];
            }
                
        }
        AddLasersToPool(1);
        laserList[ laserList.Count - 1 ].gameObject.SetActive(true); //añade 1 laser de hacer falta a la lista y lo coloca en lo ultimo
        return laserList[laserList.Count - 1]; //me lo retorna el ultimo creado
    }

    public GameObject RequestTO( Vector3 destiny)
    {
        for (int i = 0; i < laserList.Count; i++)
        {
            if (!laserList[i].gameObject.activeSelf)
            {
                laserList[i].gameObject.SetActive(true);
                laserList[i].transform.position = destiny;
                return laserList[i];
            }
        }
        AddLasersToPool(1);
        laserList[laserList.Count - 1].gameObject.SetActive(true); //añade 1 laser de hacer falta a la lista y lo coloca en lo ultimo
        laserList[laserList.Count - 1].transform.position = destiny;
        return laserList[laserList.Count - 1]; //me lo retorna el ultimo creado

    }
}
