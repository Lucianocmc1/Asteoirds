using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoopSpacePlayer : MonoBehaviour , ILoopPlayer
{
    [SerializeField] bool IsVertical;
    [SerializeField][Range(-5, 5)] float forceCenter;
    [SerializeField] LayerMask layerPlayer;

    public bool GetVertical() { return IsVertical; }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsVertical && layerPlayer == other.gameObject.layer)
        {
            float destinyPosition = -other.transform.position.y;
            destinyPosition = destinyPosition > 0f ? destinyPosition - forceCenter : destinyPosition + forceCenter;
            other.transform.position = new Vector2(other.transform.position.x, destinyPosition);
        }
        else if(IsVertical && layerPlayer == other.gameObject.layer) 
        {
            float destinyPosition = -other.transform.position.x;
            destinyPosition = destinyPosition > 0f ? destinyPosition - forceCenter : destinyPosition + forceCenter;
            other.transform.position = new Vector2(destinyPosition, other.transform.position.y);
        }

    }
    
}
  
public interface ILoopPlayer 
{
    public bool GetVertical();

}