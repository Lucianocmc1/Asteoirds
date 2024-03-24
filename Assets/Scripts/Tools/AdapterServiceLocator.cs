using Mono.Cecil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
    public void UnregisterAllServices()
    {
        _services.Clear();
    }
}

[Serializable]
public class AdapterServiceLocator : MonoBehaviour
{
 
    [SerializeField] DictionaryGenerics< TypeEnemy, AudioClip> dictionaryPoolingAudio;   
    [SerializeField] DictionaryGenerics< TypeEnemy, GameObject> dictionaryPoolingEfects;   
    [SerializeField] DictionaryGenerics<TypeEnemy, GameObject> dictionaryPoolingInstance;
    [SerializeField] DictionaryGenerics<TypeEnemy, GameObject> dictionaryPoolingBullet;
    [SerializeField] DetachAsteroid deatchAsteroid;
    [SerializeField] GameObject poolingAudio;
    Dictionary<TypeEnemy, AudioClip> poolingAudioClip;
    Dictionary<TypeEnemy, GameObject> poolingEfects;
    Dictionary<TypeEnemy, GameObject> poolingInstance;
    Dictionary<TypeEnemy, GameObject> poolingBulletEnemy;
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
        poolingAudioClip = dictionaryPoolingAudio.ToDictionary();   
        poolingInstance = dictionaryPoolingInstance.ToDictionary();
        poolingBulletEnemy = dictionaryPoolingBullet.ToDictionary();
    }

    public GameObject GetBullet(TypeEnemy enemy)
    {
        if (poolingBulletEnemy.ContainsKey(enemy))
            return poolingBulletEnemy[enemy].GetComponent<IBulletPoolingEnemy>().GetBullet();
        else
            Debug.Log("no encontro referencia del bullet del enemigo que recibe como parametro");

        return null;
    }

    public void PlayAudioDestroy(AudioClip audio, TypeEnemy typeEnemy) 
    {
        if (poolingAudioClip.ContainsKey(typeEnemy))
        poolingAudio.GetComponent<IPoolingAudioSource>().GetAudio().PlayOneShot(poolingAudioClip[typeEnemy]);
        else
        Debug.Log("no encontro referencia del audio del enemigo");
    } 

    public IGetSystemParticle GetPoolingParticle(TypeEnemy typeEnemy) //where T : IGetSystemParticle
    {
        if (poolingEfects.ContainsKey(typeEnemy))
         return poolingEfects[typeEnemy].GetComponent<IGetSystemParticle>();
        else
         Debug.Log("no encontro referencia de la Pooling de particulas");

        return null;
    }

    public GameObject GetPoolingEnemyInstancie(TypeEnemy typeEnemy) //where T : IGetSystemParticle // va a devolver la referencia del gameObject pooling
    {
        if (poolingInstance.ContainsKey(typeEnemy))
            return poolingInstance[typeEnemy];
        else
            Debug.Log("no encontro referencia de la Pooling de enemigos");

        return null;
    }
    public DetachAsteroid GetDeatchAsteroid() { return deatchAsteroid;} //podria cambiarlo y registrarlo en el getservice
    public void RegisterService <T>( T service)=> serviceLocator.RegisterService(service);
    public T GetService<T>()=> serviceLocator.GetServices<T>();
    public void ClearAllService()=> serviceLocator.UnregisterAllServices();

}

//referencias pooling = gameObject;
// referencias de systemParticle  = GameObject;

