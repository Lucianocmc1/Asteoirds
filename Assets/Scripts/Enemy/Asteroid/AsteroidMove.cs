using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    [SerializeField] EnemySO enemy;
    [SerializeField] float rotateMin;
    [SerializeField] float rotateMax;
    Vector2 direction;
    float rotateSpeed;
    void Start()
    {
        direction = Random.insideUnitCircle.normalized;
        rotateSpeed = Random.Range(rotateMin, rotateMax); // 30f y 60f
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * enemy.speed, Space.World);
        transform.Rotate(0f, 0f, (rotateSpeed * Time.deltaTime), Space.Self); //rota en su eje
    }
}
