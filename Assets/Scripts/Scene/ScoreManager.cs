using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance { get { return instance; } }   // lo podremos llammar desde otros scripts

    [SerializeField] createEnemyDictionary listScore;
    [SerializeField] TextMeshProUGUI textScore;
    [SerializeField] TextMeshProUGUI textTime;
    Dictionary<TypeEnemy, int> dictionaryEnemy;
    int score;
    int hours;
    int minutes;
    int seconds;
    float timeValue; 
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
    private void Update()
    {
      timeValue += Time.deltaTime;
       
      hours = Mathf.FloorToInt(timeValue / 3600);
      minutes = Mathf.FloorToInt((timeValue % 3600) / 60);
      seconds = Mathf.FloorToInt(timeValue % 60);

      string timeFormat = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

      textTime.text = timeFormat;
    }
    void MoreScore(TypeEnemy enemy)=>  textScore.text = (dictionaryEnemy.ContainsKey(enemy)) ? (score += dictionaryEnemy[enemy]).ToString() : score.ToString(); 
    public void SetScore(TypeEnemy typeEnemy) { MoreScore(typeEnemy); }
    public int GetScore() => score; 
    public int GetMinutes() => minutes;
}
