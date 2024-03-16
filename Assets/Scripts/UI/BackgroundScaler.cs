using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackgroundScaler : MonoBehaviour
{
    [SerializeField] int ordImg;
    RectTransform backgroundTransform;
    AdapterServiceLocator serviceLocator;
    IBoundPlayer boundPlayer;
    private Image image;
    private void Start()
    {

      serviceLocator = AdapterServiceLocator.Singlenton;
      boundPlayer = serviceLocator.GetService<IBoundPlayer>();
      backgroundTransform = GetComponent<RectTransform>();
      image = GetComponent<Image>();
      SetSortingOrder(ordImg);
    }
 
    void SetSortingOrder(int order)
    {
        // Asegurarse de que el componente CanvasRenderer esté presente
        CanvasRenderer canvasRenderer = image.canvasRenderer;
        Canvas canvas = GetComponentInParent<Canvas>();
        // Establecer el orden de capa
        canvas.sortingOrder = order;
    }
}
