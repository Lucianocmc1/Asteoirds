using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipReference : MonoBehaviour
{
    [SerializeField] Transform transformShip;
    private static ShipReference instance;
    public static ShipReference Singlenton { get { return instance; } private set { }  }
    private void Awake()
    {
        instance = this;
    }

    public Transform GetTransform() => transformShip;
}
