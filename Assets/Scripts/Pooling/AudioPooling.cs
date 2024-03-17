using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class AudioPooling : MonoBehaviour , IPoolingAudioSource
{
    [SerializeField] GameObject templeateAudio;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<AudioSource> audioSourceList;


    void Start()
    {
        AddAduioSourceToPool(poolSize);
    }

    private void AddAduioSourceToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var audioInstance = Instantiate( templeateAudio);
            var componentAudio = audioInstance.GetComponent<AudioSource>();
            audioInstance.transform.parent = transform;
            audioInstance.gameObject.SetActive(true);
            audioSourceList.Add(componentAudio);
        }
    }

    public AudioSource RequestAudio()
    {
        for (int i = 0; i < audioSourceList.Count; i++)
        {
            if (!audioSourceList[i].isPlaying)
            {
                audioSourceList[i].gameObject.SetActive(true);
                audioSourceList[i].Play();
                return audioSourceList[i];
            }
        }
        AddAduioSourceToPool(1);
        audioSourceList[audioSourceList.Count - 1].gameObject.SetActive(true);
        audioSourceList[audioSourceList.Count - 1].Play();
        return audioSourceList[audioSourceList.Count - 1];
    }

    public AudioSource GetAudio() => RequestAudio();
}
