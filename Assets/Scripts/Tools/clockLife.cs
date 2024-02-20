using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockLife : MonoBehaviour
{
    [SerializeField] float timeLifeSeconds;
    void Start()
    {
        StartCoroutine("TimeLife");   
    }


    IEnumerator TimeLife() 
    {
        yield return new WaitForSeconds(timeLifeSeconds);
        gameObject.SetActive(false);
    }
}
