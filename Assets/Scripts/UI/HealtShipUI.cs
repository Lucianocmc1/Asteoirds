using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealtShipUI : MonoBehaviour
{
    private Dictionary<int, GameObject> healths;

    private static HealtShipUI instance;
    public static HealtShipUI Instance
    { 
        get{return instance;} private set { }
    }

    void Awake()
    {
        if (instance == null)
         instance = this;
        else
         Destroy(gameObject);
        
        healths = new Dictionary<int, GameObject>();
    }
    public void AddHealt(GameObject health, int index) => healths.Add( index, health);
    public void LostHealt(int lastIndex) 
    {
        Destroy(healths[lastIndex]);
        healths.Remove(lastIndex);
    }
}
