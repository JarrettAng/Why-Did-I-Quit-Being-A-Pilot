using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class EndingTransition : MonoBehaviour
{
    [YarnCommand("ShowEnding")]
    public void ShowEnding() {
        GameSceneManager.Instance.LoadFinalScene();
    }   
}
