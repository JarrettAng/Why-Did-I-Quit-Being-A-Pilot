using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class BedRoomScene : Scene
{
    [Header("Dialogue Sets")]
    [SerializeField] protected DialoguePosition[] set1 = default;
    [SerializeField] protected DialoguePosition[] set2 = default;

    [Header("Object Sets")]
    [SerializeField] protected GameObject objectSet1 = default;
    [SerializeField] protected GameObject objectSet2 = default;

    [Header("Poses")]
    [SerializeField] private GameObject daughterConcern = default;
    [SerializeField] private GameObject bedSit = default;
    [SerializeField] private GameObject bedSleep = default;

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
            case "REST":
                ShowRestingPose();
                break;
            case "WAKEUP":
                ShowWakeupPose();
                break;
            case "SIT":
                ShowSitPose();
                break;
            default:
                ThrowUnknownPoseError(pose, type);
                break;
        }
    }

    private void ShowRestingPose() {
        daughterConcern.SetActive(false);
        bedSit.SetActive(false);
        bedSleep.SetActive(true);
    }

    private void ShowWakeupPose() {
        daughterConcern.SetActive(true);
        bedSit.SetActive(false);
        bedSleep.SetActive(true);
    }

    private void ShowSitPose() {
        daughterConcern.SetActive(false);
        bedSit.SetActive(true);
        bedSleep.SetActive(false);
    }

    public override void ResetPoses() {
        daughterConcern.SetActive(false);
        bedSit.SetActive(false);
        bedSleep.SetActive(false);
    }
}
