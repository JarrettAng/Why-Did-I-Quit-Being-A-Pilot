using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class FrontDoorAreaScene : Scene
{
    [Header("Dialogue Sets")]
    [SerializeField] protected DialoguePosition[] set1 = default;
    [SerializeField] protected DialoguePosition[] set2 = default;

    [Header("Poses Set 1")]
    [SerializeField] private GameObject poseSet1 = default;
    [SerializeField] private GameObject grandfather = default;
    [SerializeField] private GameObject son = default;
    [SerializeField] private GameObject grandson = default;
    [SerializeField] private GameObject daughter = default;

    [Header("Poses Set 2")]
    [SerializeField] private GameObject poseSet2 = default;
    [SerializeField] private GameObject confused = default;
    [SerializeField] private GameObject phoneStare = default;
    [SerializeField] private GameObject phoneTalk = default;
    [SerializeField] private GameObject superConfused = default;

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

    [YarnCommand("ShowPose")]
    public override void ShowPose(string pose) {
        switch(pose) {
            case "WELCOME":
                ShowWelcomePose();
                break;
            case "DAUGHTER":
                ShowDaughterPose();
                break;
            case "CONFUSED":
                ShowConfusedPose();
                break;
            case "SUPERCONFUSED":
                ShowSuperConfusedPose();
                break;
            case "PHONESTARE":
                ShowPhoneStarePose();
                break;
            case "PHONETALK":
                ShowPhoneTalkPose();
                break;
            default:
                ThrowUnknownPoseError(pose, type);
                break;
        }
    }

    private void ShowWelcomePose() {
        poseSet1.SetActive(true);
        poseSet2.SetActive(false);

        grandfather.SetActive(true);
        son.SetActive(true);
        grandson.SetActive(true);
        daughter.SetActive(false);
    }

    private void ShowDaughterPose() {
        daughter.SetActive(true);
    }

    private void ShowConfusedPose() {
        poseSet1.SetActive(false);
        poseSet2.SetActive(true);

        confused.SetActive(true);
        phoneStare.SetActive(false);
        phoneTalk.SetActive(false);
        superConfused.SetActive(false);
    }

    private void ShowSuperConfusedPose() {
        confused.SetActive(false);
        phoneStare.SetActive(false);
        phoneTalk.SetActive(false);
        superConfused.SetActive(true);
    }

    private void ShowPhoneStarePose() {
        confused.SetActive(false);
        phoneStare.SetActive(true);
        phoneTalk.SetActive(false);
        superConfused.SetActive(false);
    }

    private void ShowPhoneTalkPose() {
        confused.SetActive(false);
        phoneStare.SetActive(false);
        phoneTalk.SetActive(true);
        superConfused.SetActive(false);
    }

    public override void ResetPoses() {
        poseSet1.SetActive(false);
        poseSet2.SetActive(false);

        grandfather.SetActive(false);
        son.SetActive(false);
        grandson.SetActive(false);
        daughter.SetActive(false);
    }
}
