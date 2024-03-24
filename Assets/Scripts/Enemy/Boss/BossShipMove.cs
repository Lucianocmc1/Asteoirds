using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossShipMove : MonoBehaviour
{
    [SerializeField] float radiusToOrbit;
    [SerializeField] EnemySO enemy;
    Transform target;
    private void Awake()
    {
        target = AdapterServiceLocator.Singlenton.GetService<IShip>().GetTransform();

    }

    void Update()
    {
        if ( DistanceTarget() < radiusToOrbit) // si la distancia es menor orbitar el objeto
            transform.RotateAround(target.position, Vector2.up, enemy.speedRotate);
        else
            ToTarget();
    }
    // void OrbitToTarget() 
    //{

    //}

    float DistanceTarget() => (target.position - transform.position).magnitude;
    void ToTarget()
    {
        var direction = transform.position - target.position;
        transform.position += direction * enemy.speed;
    }
    void GetTransform() => target = ( target is null ) ? AdapterServiceLocator.Singlenton.GetService<IShip>().GetTransform(): target;


    private void OnDrawGizmos()
    {
        if(target is null)  GetTransform();
        Debug.DrawLine(transform.position, target.position, Color.green, float.MaxValue);
    }
    private void OnDrawGizmosSelected()
    {
        Debug.DrawLine(transform.position, target.position, Color.green, float.MaxValue);
    }
}
