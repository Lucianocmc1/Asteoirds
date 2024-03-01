using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mediator : MonoBehaviour
{
  [SerializeField] DataGame gameData;
  [SerializeField] HealthShip eventDie;
  [SerializeField] GameObject panelGameOver;

  private void Start()
  {
     panelGameOver.SetActive(false);
     eventDie.OnPlayerDeath.AddListener(HandlePlayerDeath);
  }

  void HandlePlayerDeath()
  {
     panelGameOver.SetActive(true);
     gameData.Active();
  }
}
// este hace de mediator entre PanelGameOver
//
//