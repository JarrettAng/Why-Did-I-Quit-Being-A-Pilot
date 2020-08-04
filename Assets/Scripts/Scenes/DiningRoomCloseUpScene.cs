using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DiningRoomCloseUpScene : Scene
{
    [Header("Dialogue Sets")]
    [SerializeField] protected DialoguePosition[] set1 = default;
    [SerializeField] protected DialoguePosition[] set2 = default;

    [Header("Object Sets")]
    [SerializeField] protected GameObject objectSet1 = default;
    [SerializeField] protected GameObject objectSet2 = default;

    [Header("Poses")]
    [SerializeField] private GameObject grandfatherCalm = default;
    [SerializeField] private GameObject grandfatherRageQuit = default;
    [SerializeField] private GameObject grandfatherQuestioning = default;
    [SerializeField] private GameObject daughterNormal = default;
    [SerializeField] private GameObject daughterPanic = default;
    [SerializeField] private GameObject daughterConfess = default;

    public override void ToggleActive(bool state) {
        rootCanvas.SetActive(state);

        if(state) ResetPoses();
    }

    [YarnCommand("UseDialoguePositionSet1")]
    public void UseDialoguePositionSet1() {
        dialoguePositions = new List<DialoguePosition>(set1);
        InitializeDialoguePositionsDictionary();
    }

    [YarnCommand("UseDialoguePositionSet2")]
    public void UseDialoguePositionSet2() {
        dialoguePositions = new List<DialoguePosition>(set2);
        InitializeDialoguePositionsDictionary();
    }

    [YarnCommand("UseObjectSet1")]
    public void UseObjectSet1() {
        objectSet1.SetActive(true);
        objectSet2.SetActive(false);
    }

    [YarnCommand("UseObjectSet2")]
    public void UseObjectSet2() {
        objectSet1.SetActive(false);
        objectSet2.SetActive(true);
    }

    [YarnCommand("ShowPose")]
    public override void ShowPose(string pose) {
        switch(pose) {
            case "QUESTIONSTART":
                ShowQuestioningStartPose();
                break;
            case "RAGEQUIT":
                ShowRageQuitPose();
                break;
            case "CONFESSION":
                ShowConfessionPose();
                break;
            case "ENDCONFESSION":
                ShowEndConfessionPose();
                break;
            default:
                ThrowUnknownPoseError(pose, type);
                break;
        }
    }

    private void ShowQuestioningStartPose() {
        grandfatherCalm.SetActive(false);
        grandfatherRageQuit.SetActive(false);
        grandfatherQuestioning.SetActive(true);
        daughterNormal.SetActive(true);
        daughterPanic.SetActive(false);
        daughterConfess.SetActive(false);
    }

    private void ShowRageQuitPose() {
        grandfatherCalm.SetActive(false);
        grandfatherRageQuit.SetActive(true);
        grandfatherQuestioning.SetActive(false);
        daughterNormal.SetActive(false);
        daughterPanic.SetActive(true);
        daughterConfess.SetActive(false);
    }

    private void ShowConfessionPose() {
        grandfatherCalm.SetActive(true);
        grandfatherRageQuit.SetActive(false);
        grandfatherQuestioning.SetActive(false);
        daughterNormal.SetActive(false);
        daughterPanic.SetActive(false);
        daughterConfess.SetActive(true);
    }

    private void ShowEndConfessionPose() {
        daughterNormal.SetActive(true);
        daughterConfess.SetActive(false);
    }

    public override void ResetPoses() {
        grandfatherCalm.SetActive(false);
        grandfatherRageQuit.SetActive(false);
        grandfatherQuestioning.SetActive(false);
        daughterNormal.SetActive(false);
        daughterPanic.SetActive(false);
        daughterConfess.SetActive(false);
    }
}
