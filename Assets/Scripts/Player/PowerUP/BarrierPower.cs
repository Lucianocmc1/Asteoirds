using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierPower : MonoBehaviour
{
    GetRefencie refencie;
    [SerializeField] LayerMask layerEnemy;
    private void Start()
    {
        refencie = GetRefencie.Singlenton;
    }

    private void Update()
    {
        transform.position = refencie.GetShipReference().transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (layerEnemy == other.gameObject.layer)
        {
         other.gameObject.GetComponent<IDestroy>().OnDestroyed(true);
         other.gameObject.gameObject.SetActive(false);
        }
       
    }
}
