using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletPooling
{
    public GameObject GetBullet();
}

public interface IBulletPoolingEnemy 
{
    public GameObject GetBullet(Vector3 position);
    public GameObject GetBullet();
}

public interface IBulletBeheviour 
{
    public void Shoot(Vector2 from, float speed, Vector2 playerPosition);

}