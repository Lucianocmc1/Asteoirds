using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BarrierPower : MonoBehaviour 
{
    AdapterServiceLocator serviceLocator;
    IHealtPlayer healtShip;
    [SerializeField] LayerMask layerEnemy;
    [SerializeField] LayerMask layerBulletEnemy;
    bool start=false;
    private void Start()
    {
        SetReference();
        OnPower();
        start = true;
    }
    public void OnPower() => healtShip.OnDeath();
    private void OnEnable()
    {
       if(start)
       OnPower();
    }
    private void Update()
    {
        transform.position = healtShip.GetTransform().position;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (layerEnemy == other.gameObject.layer || layerBulletEnemy == other.gameObject.layer)
        other.gameObject.GetComponent<IDestroy>().OnDestroyed(true);
    }
    void SetReference()
    {
        serviceLocator = AdapterServiceLocator.Singlenton;
        healtShip = serviceLocator.GetService<IHealtPlayer>();
        healtShip.OnDeath();
    }
}
