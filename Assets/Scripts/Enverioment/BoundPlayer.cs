using UnityEngine;

public class BoundPlayer : MonoBehaviour
{
    [SerializeField] Transform colliderVertical;
    [SerializeField] Transform colliderHorizontal;
    private BoxCollider2D boxCollider;
    float minX;
    float maxX;
    float maxY;
    float minY;
    void Awake()
    {
        boxCollider = gameObject.AddComponent<BoxCollider2D>();
        SetBounds();
    }

    private void SetBounds()
    {
        boxCollider.size = new Vector2(Camera.main.aspect * 2f * Camera.main.orthographicSize, 2f * Camera.main.orthographicSize);
        boxCollider.isTrigger = true;
        minX = boxCollider.bounds.min.x;
        maxX = boxCollider.bounds.max.x;
        maxY = boxCollider.bounds.max.y;
        minY = boxCollider.bounds.min.y;
        boxCollider.enabled = false;
    }
    
    public BoundPlayer GetBound()=> this;
    public Vector3 GetBoundX()=>new  Vector3(minX, maxX);
    public Vector3 GetBoundY()=> new Vector3(minY, maxY);
 }

 
