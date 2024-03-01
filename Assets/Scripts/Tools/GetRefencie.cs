using Mono.Cecil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GetRefencie : MonoBehaviour
{
    [SerializeField] DictionaryGenerics< TypeEnemy, GameObject> dictionaryPoolingEfects;   
    [SerializeField] DictionaryGenerics<TypeEnemy, GameObject> dictionaryPoolingInstance;
    [SerializeField] DetachAsteroid deatchAsteroid;
    Dictionary<TypeEnemy, GameObject> poolingEfects;
    Dictionary<TypeEnemy, GameObject> poolingInstance;
  
    static GetRefencie instance;
    public static GetRefencie Singlenton { get { return instance; } private set { } }
    
    private void Awake()
    {
        if (instance == null)
         instance = this;
        else
         Destroy(gameObject);

        poolingEfects = dictionaryPoolingEfects.ToDictionary();
        poolingInstance = dictionaryPoolingInstance.ToDictionary();
    }

    public IGetSystemParticle GetReferenceParticle(TypeEnemy TypeEnemy) //where T : IGetSystemParticle
    {
        if (poolingEfects.ContainsKey(TypeEnemy))
         return poolingEfects[TypeEnemy].GetComponent<IGetSystemParticle>();
        else
         Debug.Log("no encontro referencia de la Pooling de particulas");

        return null;
    }

    public GameObject GetReferencePoolingInstancie(TypeEnemy typeEnemy) //where T : IGetSystemParticle
    {
        if (poolingInstance.ContainsKey(typeEnemy))
            return poolingInstance[typeEnemy];
        else
            Debug.Log("no encontro referencia de la Pooling de enemigos");

        return null;
    }


    public DetachAsteroid GetDeatchAsteroid() { return deatchAsteroid;}
}

//referencias pooling = gameObject;
// referencias de systemParticle  = GameObject;

