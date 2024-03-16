using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mediator : MonoBehaviour
{
  [SerializeField] DataGame gameData;
  [SerializeField] HealthShip eventDie;
  [SerializeField] GameObject panelGameOver;
  AdapterServiceLocator adapterServiceLocator;
  private void Awake() //antes estaba en start
  {
     panelGameOver.SetActive(false);
     eventDie.OnPlayerDeath.AddListener(HandlePlayerDeath);
     adapterServiceLocator = AdapterServiceLocator.Singlenton;
  }

  void HandlePlayerDeath()
  {
     panelGameOver.SetActive(true);
     gameData.Active();
     adapterServiceLocator.ClearAllService();
  }
}
// este hace de mediator entre PanelGameOver
//
//