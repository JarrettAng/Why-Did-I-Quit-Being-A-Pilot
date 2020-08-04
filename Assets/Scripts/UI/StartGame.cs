using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class StartGame : MonoBehaviour
{
    public void StartTheGame() {
        SceneManager.LoadScene("Main");
    }
}
