using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
public abstract class Scene : MonoBehaviour
{
    [Header("References")]
    [SerializeField] protected GameObject rootCanvas = default;
    [SerializeField] protected List<DialoguePosition> dialoguePositions = default;

    [Header("Attributes")]
    [SerializeField] protected SceneType type = SceneType.NULL;

    private Dictionary<string, RectTransform> dialoguePositionsDictionary;

    public SceneType Type {
        get { return type; }
    }

    public abstract void ToggleActive(bool state);

    public abstract void ShowPose(string pose);

    public abstract void ResetPoses();

    public Vector2 GetPositionFor(string character) {
        if(dialoguePositionsDictionary == null) InitializeDialoguePositionsDictionary();

        if(dialoguePositionsDictionary.TryGetValue(character, out RectTransform value)) {
            return value.anchoredPosition;
        } else {
            Debug.LogErrorFormat("DialogueRunner tried to get an unknown dialogue position for character ({0}) in scene {1}", character, type);
            return Vector2.zero;
        }
    }

    protected void ThrowUnknownPoseError(string pose, SceneType type) {
        Debug.LogErrorFormat("DialogueRunner tried to show an unknown pose ({0}) in scene {1}", pose, type);
    }

    protected void InitializeDialoguePositionsDictionary() {
        dialoguePositionsDictionary = new Dictionary<string, RectTransform>();
        foreach(DialoguePosition position in dialoguePositions) {
            dialoguePositionsDictionary.Add(position.Character, position.Transform);
        }
    }
}
