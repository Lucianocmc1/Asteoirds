using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtsPower : MonoBehaviour
{
    [SerializeField] LayerMask layerMaskPlayer;
    private void OnTriggerEnter2D(Collider2D other) //configurado por layre que solo colisiona con player
    {
        if (other.gameObject.layer != layerMaskPlayer) return;
        var player = other.gameObject.GetComponent<HealthShip>();
        player?.MoreHealt();
        gameObject.SetActive(false);
    }

}
