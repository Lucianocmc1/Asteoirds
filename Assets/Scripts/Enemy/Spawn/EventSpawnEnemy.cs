using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventSpawnEnemy : EventArgs
{
    public GameObject EntyEnemy { get; private set; }

    public EventSpawnEnemy(GameObject enemy)
    {
        EntyEnemy = enemy;
    }
}
