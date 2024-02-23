using UnityEngine;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;
public class Tools : MonoBehaviour
{
    static Tools instance;
    public static Tools Instance { get { return instance; } private set { } }
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
  
}



