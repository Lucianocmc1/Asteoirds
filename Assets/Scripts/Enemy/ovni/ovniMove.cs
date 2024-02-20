using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ovniMove : MonoBehaviour
{
    [SerializeField] EnemySO enemyData;
    Vector2 direction;
    void Start() =>  InvokeRepeating("RandoomDirection", 0.1f, RandomTime());
    void Update()=> Move();
    void Move() => transform.Translate(direction * Time.deltaTime * enemyData.speed, Space.World);
    void RandoomDirection() => direction = Random.insideUnitCircle.normalized;
    private float RandomTime()=>  Random.Range(2f, 5f);
}
