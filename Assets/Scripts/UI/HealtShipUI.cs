using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealtShipUI : MonoBehaviour, IHealtUI
{
    private Dictionary<int, GameObject> healths;

   // private static HealtShipUI instance;
   /* public static HealtShipUI Instance
    { 
        get{return instance;} private set { }
    }*/

    void Awake()
    {
     /*if (instance == null)
         instance = this;
       else
         Destroy(gameObject);
     */
      AdapterServiceLocator.Singlenton.RegisterService<IHealtUI>(this);
      healths = new Dictionary<int, GameObject>();
    }
    public void AddHealt(GameObject healthPrefab, int index) => healths.Add( index, healthPrefab);
    public void LostHealt(int lastIndex) 
    {
      Destroy(healths[lastIndex]);
      healths.Remove(lastIndex);
    }
}
