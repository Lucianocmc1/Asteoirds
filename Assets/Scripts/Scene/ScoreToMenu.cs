using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

public class ScoreToMenu : MonoBehaviour
{
    [SerializeField] GameObject backgroundPanelScore;
    [SerializeField] TextMeshProUGUI textScore;
    bool end = false;

    private void Update()
    {

        if( Input.anyKey && end && !Input.GetKey(KeyCode.Mouse0))
        { 
          backgroundPanelScore.SetActive(false);
          end = false;
        }
    }
    List<KeyValuePair<string, int>> LoadScores()
    {
        List<KeyValuePair<string, int>> playerList = new List<KeyValuePair<string, int>>();

        for (int i = 0; i < 5; i++)
        {
            string playerName = PlayerPrefs.GetString($"PlayerName_{i}", "");
            int playerScore = PlayerPrefs.GetInt($"PlayerScore_{i}", 0);

            playerList.Add(new KeyValuePair<string, int>(playerName, playerScore));
        }

        return playerList;
    }

    void GetScore()
    {
        textScore.enabled = true;
        textScore.text = string.Empty;
        int top = 1;
        List<KeyValuePair<string, int>> playerList = LoadScores();

        foreach (var scorePoint in playerList)
        {
            string namePlayer = scorePoint.Key;
            int score = scorePoint.Value;
            textScore.text += string.Format("{0} - {1} : {2}\n", top++, namePlayer, score);
        }
        end = true;
    }

    public void ResetScore()
    {
        List<KeyValuePair<string, int>> playerList = LoadScores();
        textScore.enabled = true;
        textScore.text = string.Empty;

        for (int i = 0; i < playerList.Count; i++)
        {
            playerList[i] = new KeyValuePair<string, int>("-", 0);
        }

        end = true;

        SaveScores(playerList);
        GetScore();
    }
    void SaveScores(List<KeyValuePair<string, int>> playerList)
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetString($"PlayerName_{i}", playerList[i].Key);
            PlayerPrefs.SetInt($"PlayerScore_{i}", playerList[i].Value);
        }
    }
    public void ButtonOn()
    {
        GetScore();
        backgroundPanelScore.SetActive(true);
    }
}
