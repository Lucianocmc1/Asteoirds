using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WavesEnemyUI : MonoBehaviour
{
    [SerializeField] TextMeshPro  wave;
    [SerializeField] TextMeshPro enemiesCurrent;
    EventHandler < DataEvents<int>> enemiesCurrentValues;
    
    void Start()
    {
        wave.text = "1";
        enemiesCurrent.text = enemiesCurrentValues.ToString();
    }
     
    public void OnChagedAmmountEnemies(int enemyCurrent, int reamingEnemy , int ammountWave )
    {
        EventHandler<DataEvents<int>> eventHandler = enemiesCurrentValues;
        if (eventHandler != null)
        eventHandler(this, new DataEvents<int>(enemyCurrent, reamingEnemy , ammountWave)); 
     
    }
}
