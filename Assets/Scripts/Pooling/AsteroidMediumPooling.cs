using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMediumPooling : MonoBehaviour, IPoolingEnemy
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private List<GameObject> asteroidsList;
    [SerializeField] private int poolSize = 10;

    private static AsteroidMediumPooling instance;
    public static AsteroidMediumPooling Instance { get { return instance; } }   // lo podremos llammar desde otros scripts

    private void Awake() //por si es llamdado mas de una ves no me va a duplicar la lista de pooling me elimina una
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start() => AddAsteroidToPool(poolSize);

    private void AddAsteroidToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var asteroids = prefab;
            var asteroidInstance = Instantiate(asteroids);
            asteroidInstance.transform.parent = transform;
            asteroidInstance.SetActive(false);
            asteroidsList.Add(asteroidInstance);
        }
    }

    public GameObject RequestAsteroid()
    {
        for (int i = 0; i < asteroidsList.Count; i++)
        {
            if (!asteroidsList[i].gameObject.activeSelf)
            {
                asteroidsList[i].gameObject.SetActive(true);
                return asteroidsList[i];
            }
        }

        AddAsteroidToPool(1);
        asteroidsList[asteroidsList.Count - 1].gameObject.SetActive(true);
        return asteroidsList[asteroidsList.Count - 1];
    }

    public GameObject RequestEnemy() => RequestAsteroid();

}
