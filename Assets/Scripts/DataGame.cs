using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataGame : MonoBehaviour
{
    [SerializeField] int ammountTopScore;
    [SerializeField] TextMeshProUGUI textScore;
    [SerializeField] TMP_InputField inputName;
    Dictionary<string, int> playerScore = new Dictionary<string, int>();
    bool active = false;
    bool end = false;
    List<KeyValuePair<string, int>> LoadScores()
    {
        List<KeyValuePair<string, int>> playerList = new List<KeyValuePair<string, int>>();

        for (int i = 0; i < ammountTopScore; i++)
        {
            string playerName = PlayerPrefs.GetString($"PlayerName_{i}", "");
            int playerScore = PlayerPrefs.GetInt($"PlayerScore_{i}", 0);

            playerList.Add(new KeyValuePair<string, int>(playerName, playerScore));
        }

        return playerList;
    }
    private void Update()
    {
        if (active && Input.anyKeyDown && !end)
        {
          inputName.gameObject.SetActive(true);
          inputName.Select();
          inputName.ActivateInputField();
          if (Input.GetKey(KeyCode.Return))
          SendName();
        }
        if(end && Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Active()=> active = true;
    public void SendName()
    {
      textScore.enabled = false;
      if( inputName.text.Length <= 6 && inputName.text.Length >= 1)
      {
        RegisterScore(ScoreManager.Instance.GetScore(), inputName.text);
        inputName.enabled = false;
        GetScore();
      }
      inputName.gameObject.SetActive(false);
    } 
    void RegisterScore(int score, string namePlayer)//top 5 Score
    {
        List<KeyValuePair<string, int>> playerList = LoadScores();
        // Asegurarse de que playerList tenga al menos ammountTopScore elementos
        while (playerList.Count < ammountTopScore)
        {
            playerList.Add(new KeyValuePair<string, int>("", 0));
        }

        for (int i = 0; i < ammountTopScore; i++)
        {
          if (playerList[i].Value < score)
          {
           //if (!playerList.Exists(pair => pair.Key == namePlayer))
           playerList[i] = new KeyValuePair<string, int>(namePlayer, score);
           break;
          }
        }
         SaveScores(playerList);
   }

   void SaveScores(List<KeyValuePair<string, int>> playerList)
   {
     for (int i = 0; i < ammountTopScore; i++)
     {
       PlayerPrefs.SetString($"PlayerName_{i}", playerList[i].Key);
       PlayerPrefs.SetInt($"PlayerScore_{i}", playerList[i].Value);
     }
   }
   void GetScore()
   {
      textScore.enabled = true;
      int top = 1;
      textScore.text = "";
      List<KeyValuePair<string, int>> playerList = LoadScores();

      foreach (var scorePoint in playerList)
      {
       string namePlayer = scorePoint.Key;
       int score = scorePoint.Value;

       textScore.text += string.Format("{0} - {1} : {2}\n", top++, namePlayer, score);
      }
     end = true;
   }
   
}
