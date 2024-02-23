using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtsPower : MonoBehaviour
{
    [SerializeField] LayerMask layerMaskPlayer;
    private void OnTriggerEnter2D(Collider2D other) //configurado por layre que solo colisiona con player
    {
        var player = other.GetComponent<IHealtPlayer>(); 
        if (player is not null )
        player?.MoreHealt();
        gameObject.SetActive(player is null);
        
    }

}
