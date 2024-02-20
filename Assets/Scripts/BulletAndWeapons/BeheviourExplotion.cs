using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BeheviourExplotion : MonoBehaviour
{
    [SerializeField] float scaleFinal;
    [SerializeField] float scaleCurrent;
    [SerializeField] float time;
    [SerializeField] float speedScale;

    private void Start()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
       StartCoroutine(ScaleUpdate());
    }
 
    private void END()=> this.gameObject.SetActive(false);
   
    private IEnumerator ScaleUpdate() 
    {
        float timeElapse = 0f;
        while(timeElapse < time) 
        { 
         var Scale = Mathf.Lerp(scaleCurrent, scaleFinal, timeElapse / time);
         this.transform.localScale = new Vector2(Scale,Scale);
         timeElapse +=  speedScale * Time.deltaTime;
            yield return null;
        }
        END();
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.gameObject.GetComponent<IDestroy>();
        enemy?.OnDestroyed(true);
    }
}
