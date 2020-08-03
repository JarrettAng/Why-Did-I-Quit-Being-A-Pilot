using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DiningRoomScene : Scene
{
    [Header("Poses")]
    [SerializeField] private GameObject grandfather = default;
    [SerializeField] private GameObject son = default;
    [SerializeField] private GameObject grandson = default;
    [SerializeField] private GameObject daughter = default;

    public override void ToggleActive(bool state) {
        rootCanvas.SetActive(state);

        if(state) ResetPoses();
    }

    [YarnCommand("ShowPose")]
    public override void ShowPose(string pose) {
        switch(pose) {
            case "DINING":
                ShowDiningPose();
                break;
            case "BREAKFAST":
                ShowBreakfastPose();
                break;
            case "DINNER":
                ShowDinnerPose();
                break;
            case "DAUGHTERAPPEAR":
                ShowDaughterAppearPose();
                break;
            case "DAUGHTERDISAPPEAR":
                ShowDaughterDisappearPose();
                break;
            default:
                ThrowUnknownPoseError(pose, type);
                break;
        }
    }

    private void ShowDiningPose() {
        grandfather.SetActive(true);
        son.SetActive(true);
        grandson.SetActive(true);
        daughter.SetActive(true);
    }

    private void ShowBreakfastPose() {
        grandfather.SetActive(true);
        son.SetActive(false);
        grandson.SetActive(false);
        daughter.SetActive(false);
    }

    private void ShowDaughterAppearPose() {
        daughter.SetActive(true);
    }

    private void ShowDaughterDisappearPose() {
        daughter.SetActive(false);
    }

    private void ShowDinnerPose() {
        grandfather.SetActive(true);
        daughter.SetActive(true);
    }

    public override void ResetPoses() {
        grandfather.SetActive(false);
        son.SetActive(false);
        grandson.SetActive(false);
        daughter.SetActive(false);
    }
}
