using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour , IPoolingEnemy
{

    [SerializeField] private GameObject ovniPrefab;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> ovniList;


    void Start()
    {
        AddEnemyToPool(poolSize);
    }

    private void AddEnemyToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var ovni = ovniPrefab; //instancia el ovni
            var ovniInstance = Instantiate(ovni);
            ovniInstance.transform.parent = transform;
            ovniInstance.SetActive(false);
            ovniList.Add(ovniInstance);
        }
    }

    public GameObject RequestEnemi()
    {
        for (int i = 0; i < ovniList.Count; i++)
        {
            if (!ovniList[i].gameObject.activeSelf)
            {
                ovniList[i].gameObject.SetActive(true);
                return ovniList[i];
            }

        }
        AddEnemyToPool(1);
        ovniList[ovniList.Count - 1].gameObject.SetActive(true); 
        return ovniList[ovniList.Count - 1]; 
    }
    
   public GameObject RequestEnemy() => RequestEnemi();
}
