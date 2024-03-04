using Mono.Cecil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public interface IDataSarver
{
   public void SetString(string key, string value);
   public string GetString(string key, string deafaultValue = default);
   public void SetInt(string key, int value);
   public string GetInt(string key, string deafaultValue = default);


}

public class ServiceLocator
{
    public static ServiceLocator Instance => _instance ?? (_instance = new ServiceLocator());
    static ServiceLocator _instance;
    readonly Dictionary<Type, object> _services;
    public ServiceLocator()
    {
       _services = new Dictionary<Type, object>();
    }
    public void RegisterService<T>( T service)
    {
     var type = typeof(T);
     Assert.IsFalse(_services.ContainsKey(type),$"Service {type} already registred");
     _services.Add(type, service);
    }

    public T GetServices<T>()
    {
       var type = typeof (T);
       if(!_services.TryGetValue(type, out var service))
       {
          throw new Exception($"Service {type} not found");
       }
        return (T)service;
    }
}



[Serializable]
public class AdapterServiceLocator : MonoBehaviour
{
    //[SerializeField] HealthShip healthShip;
    [SerializeField] BoundPlayer boundPlayer;
    [SerializeField] DictionaryGenerics< TypeEnemy, GameObject> dictionaryPoolingEfects;   
    [SerializeField] DictionaryGenerics<TypeEnemy, GameObject> dictionaryPoolingInstance;
    [SerializeField] DetachAsteroid deatchAsteroid;
    Dictionary<TypeEnemy, GameObject> poolingEfects;
    Dictionary<TypeEnemy, GameObject> poolingInstance;
    ServiceLocator serviceLocator;
    static AdapterServiceLocator instance;
    public static AdapterServiceLocator Singlenton { get { return instance; } private set { } }
    
    private void Awake()
    {
        if (instance == null)
         instance = this;
        else
         Destroy(gameObject);

        serviceLocator = ServiceLocator.Instance;
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

    public GameObject GetReferencePoolingInstancie(TypeEnemy typeEnemy) //where T : IGetSystemParticle // va a devolver la referencia del gameObject pooling
    {
        if (poolingInstance.ContainsKey(typeEnemy))
            return poolingInstance[typeEnemy];
        else
            Debug.Log("no encontro referencia de la Pooling de enemigos");

        return null;
    }

    public BoundPlayer GetBounds() => boundPlayer.GetBound();
    public DetachAsteroid GetDeatchAsteroid() { return deatchAsteroid;}
    public ShipReference GetShipReference() => ShipReference.Singlenton;
   // public HealthShip GetHealthShip() => healthShip;

    public void RegisterService <T>( T service)=> serviceLocator.RegisterService(service);
    public T GetService<T>()=> serviceLocator.GetServices<T>();
    
}

//referencias pooling = gameObject;
// referencias de systemParticle  = GameObject;

