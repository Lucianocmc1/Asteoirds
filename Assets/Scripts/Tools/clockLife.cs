using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class clockLife : MonoBehaviour
{
    [SerializeField] float timeLifeSeconds;
    bool onTimeLife;
    void Start()
    {
        StartCoroutine("TimeLife");   
    }
    
    void OnEnable() 
    {
        if(!IsInvoking("TimeLife"))
        StartCoroutine("TimeLife");
    }

    IEnumerator TimeLife() 
    {
        yield return new WaitForSeconds(timeLifeSeconds);
        gameObject.SetActive(false);
    }
}
