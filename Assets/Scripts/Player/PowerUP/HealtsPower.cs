using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtsPower : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) //configurado por layre que solo colisiona con player
    {
        var playerLayer = other.gameObject.layer;
        var player = other.gameObject.GetComponent<HealthShip>();
        player.MoreHealt();
        gameObject.SetActive(false);
    }
}
