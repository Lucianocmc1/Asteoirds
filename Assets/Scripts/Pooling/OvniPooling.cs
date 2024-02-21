using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvniPooling : MonoBehaviour , IPoolingEnemy
{

    [SerializeField] private GameObject ovniPrefab;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> ovniList;

    private static OvniPooling instance;
    public static OvniPooling Instance { get { return instance; } }   // lo podremos llammar desde otros scripts

    private void Awake() //por si es llamdado mas de una ves no me va a duplicar la lista de pooling me elimina una
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


    void Start()
    {
        AddOvniToPool(poolSize);
    }

    private void AddOvniToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var ovni = ovniPrefab; //instancia el ovni
            ovni.gameObject.SetActive(false); // lo desactiva no lo elimina
            ovniList.Add(ovni); //lo añade a la lista
        }
    }

    public GameObject RequestOvni()
    {
        for (int i = 0; i < ovniList.Count; i++)
        {
            if (!ovniList[i].gameObject.activeSelf)
            {
                ovniList[i].gameObject.SetActive(true);
                return ovniList[i];
            }

        }
        AddOvniToPool(1);
        ovniList[ovniList.Count - 1].gameObject.SetActive(true); 
        return ovniList[ovniList.Count - 1]; 
    }
    public GameObject RequestEnemy() => RequestOvni();
}
