using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class LivingRoomScene : Scene
{
    [Header("Dialogue Sets")]
    [SerializeField] protected DialoguePosition[] set1 = default;
    [SerializeField] protected DialoguePosition[] set2 = default;

    [Header("Object Sets")]
    [SerializeField] protected GameObject objectSet1 = default;
    [SerializeField] protected GameObject objectSet2 = default;

    [Header("Poses")]
    [SerializeField] private GameObject read = default;
    [SerializeField] private GameObject walk = default;

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
            case "READ":
                ShowReadPose();
                break;
            case "WALK":
                ShowWalkPose();
                break;
            default:
                ThrowUnknownPoseError(pose, type);
                break;
        }
    }

    private void ShowReadPose() {
        read.SetActive(true);
        walk.SetActive(false);
    }

    private void ShowWalkPose() {
        read.SetActive(false);
        walk.SetActive(true);
    }

    public override void ResetPoses() {
        read.SetActive(false);
        walk.SetActive(false);
    }
}
