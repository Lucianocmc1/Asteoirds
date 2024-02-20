using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataShip", menuName = "ScriptableObjects/DataShip")]
public class DataPlayer : ScriptableObject
{
    public float speed;
    public float speedMax;
    public float speedBurstMax;
    public float speedBurst;
    public float speedRotate;
    public float deceleration;
}
