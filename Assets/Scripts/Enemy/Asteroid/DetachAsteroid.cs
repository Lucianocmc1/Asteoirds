using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachAsteroid : MonoBehaviour
{
    [SerializeField] int ammountAsteroid;
    
    public void Death(Vector3 position, EnemySO enemy)
    {
        GameObject asteroid;
        for (int i = ammountAsteroid;  i > 0; i--)
        {
          
          if (enemy.typeEnemy == TypeEnemy.asteroidBig)
          {
            asteroid = AsteroidMediumPooling.Instance.RequestEnemy();
            asteroid.transform.position = position;
          }
          else if( enemy.typeEnemy == TypeEnemy.asteroidMedium)
          { 
            asteroid = AsteroidSmallPooling.Instance.RequestEnemy();
            asteroid.transform.position = position;
          }
        }
        
    }

   
}
