using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachAsteroid : MonoBehaviour
{
    [SerializeField] int ammountAsteroid;
    private AdapterServiceLocator serviceLocator;

    public void Start()
    {
        serviceLocator = AdapterServiceLocator.Singlenton;
    }
    public void Death(Vector3 position, EnemySO enemy)
    {
        GameObject asteroid;
        var asteroidMedium = serviceLocator.GetReferencePoolingInstancie(TypeEnemy.asteroidMedium);
        var asteroidSmall = serviceLocator.GetReferencePoolingInstancie(TypeEnemy.asteroidSmall);
        for (int i = ammountAsteroid;  i > 0; i--)
        {
         asteroid = (enemy.typeEnemy == TypeEnemy.asteroidBig)? asteroidMedium : asteroidSmall;
         asteroid = RequestAsteroid(asteroid);
         asteroid.transform.position = position;
        }
    }

    GameObject RequestAsteroid(GameObject pooling) => pooling.GetComponent<IPoolingEnemy>().RequestEnemy(); 
}
