using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance { get { return instance; } }   // lo podremos llammar desde otros scripts

    [SerializeField] createEnemyDictionary listScore;
    [SerializeField] TextMeshProUGUI textScore;
    Dictionary<TypeEnemy, int> dictionaryEnemy;
    int score;
    private void Awake() 
    {
        if (instance == null)
         instance = this;
        else
         Destroy(gameObject);

        dictionaryEnemy = listScore.ToDictionary();
        score = 0;
        textScore.text = 0.ToString();
    }

    void MoreScore(TypeEnemy enemy)=>  textScore.text = (dictionaryEnemy.ContainsKey(enemy)) ? (score += dictionaryEnemy[enemy]).ToString() : score.ToString(); 
    public void SetScore(TypeEnemy typeEnemy) { MoreScore(typeEnemy); } 

}
