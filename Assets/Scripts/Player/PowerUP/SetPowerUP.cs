using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPowerUP : MonoBehaviour
{
    [SerializeField] LayerMask layerMaskPlayer;
    [SerializeField] PowerList powerUPList;
   
    private void OnTriggerEnter2D(Collider2D other) //configurado por layre que solo colisiona con player
    {
        var playerLayer = other.gameObject.layer; 
        var player = other.gameObject.GetComponent<PowerUP>();
        var powerUP = Random.Range(0,powerUPList.list.Length);

        player?.SetPower(powerUPList.list[powerUP]);
        gameObject.SetActive(false);
    }
}
