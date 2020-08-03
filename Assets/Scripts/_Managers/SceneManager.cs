using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SceneManager : Singleton<SceneManager>
{
    [Header("References")]
    [SerializeField] private Scene[] scenes = default;

    [Header("Read-Only")]
    [SerializeField] private Scene currentLoadedScene;

    private Dictionary<string, Scene> sceneDictionary;

    private void Awake() {
        InitializeDictionaries();
        
        void InitializeDictionaries() {
            sceneDictionary = new Dictionary<string, Scene>();
            foreach(Scene scene in scenes) {
                sceneDictionary.Add(scene.Type.ToString(), scene);
            }
        }
    }

    [YarnCommand("LoadScene")]
    public void LoadScene(string sceneName) {
        sceneDictionary.TryGetValue(sceneName, out Scene sceneToLoad);

        sceneToLoad.ToggleActive(true);

        if(currentLoadedScene != null) currentLoadedScene.ToggleActive(false);

        currentLoadedScene = sceneToLoad;
    }

    public Vector2 GetDialoguePositionFor(string character) {
        return currentLoadedScene.GetPositionFor(character);
    }
}
