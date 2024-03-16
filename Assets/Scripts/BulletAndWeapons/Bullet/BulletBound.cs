using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBound : MonoBehaviour
{
    AdapterServiceLocator serviceLocator;
    IBoundPlayer bounds;
    private void Awake()
    {
        serviceLocator = AdapterServiceLocator.Singlenton;
    }
    private void Start()
    {
        bounds = serviceLocator.GetService<IBoundPlayer>();
    }
    private void Update()
    {
        if (bounds == null) return;
        BoundScreen();
    }

    void BoundScreen() 
    {
      var boundArriveHorizontal = (transform.position.x <= bounds.GetBoundX().x || transform.position.x >= bounds.GetBoundX().y);
      var boundArriveVertical = (transform.position.y <= bounds.GetBoundY().x || transform.position.y >= bounds.GetBoundY().y);
      gameObject.SetActive(!boundArriveHorizontal && !boundArriveVertical);
    }

    
}
