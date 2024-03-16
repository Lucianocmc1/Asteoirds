using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameLoadScene : MonoBehaviour
{
    AdapterServiceLocator serviceLocator;
    [SerializeField] GameObject ship;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        serviceLocator = (serviceLocator is null) ? AdapterServiceLocator.Singlenton : serviceLocator; 
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       if (scene.name == "Game")
       ship.SetActive(true); 
       Debug.Log("La escena se ha cargado: " + scene.name);
    }

}
