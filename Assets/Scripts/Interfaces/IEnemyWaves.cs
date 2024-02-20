using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyWaves 
{
    public event EventHandler<EventArgs> OnDestroyEnemy;
}
