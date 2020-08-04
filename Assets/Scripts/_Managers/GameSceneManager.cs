using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : Singleton<GameSceneManager>
{
    [Header("Attributes")]
    [SerializeField] private string menuScene = "Menu";
    [SerializeField] private string mainScene = "Main";
    [SerializeField] private string finalScene = "Final";

    public void LoadMenuScene() {
        SceneManager.LoadScene(menuScene);
    }

    public void LoadMainScene() {
        SceneManager.LoadScene(mainScene);
    }

    public void LoadFinalScene() {
        SceneManager.LoadScene(finalScene);
    }
}
