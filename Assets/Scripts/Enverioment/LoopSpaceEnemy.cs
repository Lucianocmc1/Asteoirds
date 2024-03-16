using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoopSpaceEnemy : MonoBehaviour
{
    [SerializeField] bool IsVertical;
    [SerializeField][Range(-5, 5)] float forceCenter;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsVertical)
        {
            float destinyPosition = -other.transform.position.y;
            destinyPosition = destinyPosition > 0f ? destinyPosition - forceCenter : destinyPosition + forceCenter;
            other.transform.position = new Vector2(other.transform.position.x, destinyPosition);
        }
        else 
        {
            float destinyPosition = -other.transform.position.x;
            destinyPosition = destinyPosition > 0f ? destinyPosition - forceCenter : destinyPosition + forceCenter;
            other.transform.position = new Vector2(destinyPosition, other.transform.position.y);
        }
    }
    
}
  
