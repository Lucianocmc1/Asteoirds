using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealtPlayer
{
    public void MoreHealt();
    public HealthShip Get();
    public void OnDeath();
    public Transform GetTransform();
}
