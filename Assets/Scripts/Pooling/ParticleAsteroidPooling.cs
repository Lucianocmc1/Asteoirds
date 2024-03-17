using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAsteroidPooling : MonoBehaviour, IGetSystemParticle
{
    [SerializeField] private ParticleSystem prefabParticle;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<ParticleSystem> fvxList;

    void Start()
    {
        AddFVXToPool(poolSize);
    }

    private void AddFVXToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var fvx = prefabParticle; //instancia el ovni
            var fvxInstance = Instantiate(fvx);
            fvxInstance.transform.parent = transform;
            fvxInstance.gameObject.SetActive(true);
            fvxInstance.Stop();
            fvxList.Add(fvxInstance);
        }
    }

    public ParticleSystem RequestFVX()
    {
        for (int i = 0; i < fvxList.Count; i++)
        {
            if (!fvxList[i].isPlaying)
            {
                fvxList[i].gameObject.SetActive(true);
                fvxList[i].Play();
                return fvxList[i];
            }

        }
        AddFVXToPool(1);
        fvxList[fvxList.Count - 1].gameObject.SetActive(true);
        fvxList[fvxList.Count - 1].Play();
        return fvxList[fvxList.Count - 1];
    }

    public ParticleSystem GetSystemParticle() => RequestFVX();
}

