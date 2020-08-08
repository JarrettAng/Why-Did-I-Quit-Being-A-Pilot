using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DiningRoomScene : Scene
{
    [Header("Object Sets")]
    [SerializeField] protected GameObject objectSet1 = default;
    [SerializeField] protected GameObject objectSet2 = default;
    [SerializeField] protected GameObject objectSet3 = default;
    [SerializeField] protected GameObject objectSet4 = default;

    [Header("Poses")]
    [SerializeField] private GameObject grandfather = default;
    [SerializeField] private GameObject son = default;
    [SerializeField] private GameObject grandson = default;
    [SerializeField] private GameObject daughter = default;
    [SerializeField] private GameObject daughterNurse = default;

    public override void ToggleActive(bool state) {
        rootCanvas.SetActive(state);

        if(state) ResetPoses();
    }

    [YarnCommand("UseObjectSet1")]
    public void UseObjectSet1() {
        objectSet1.SetActive(true);
        objectSet2.SetActive(false);
        objectSet3.SetActive(false);
        objectSet4.SetActive(false);
    }

    [YarnCommand("UseObjectSet2")]
    public void UseObjectSet2() {
        objectSet1.SetActive(false);
        objectSet2.SetActive(true);
        objectSet3.SetActive(false);
        objectSet4.SetActive(false);
    }

    [YarnCommand("UseObjectSet3")]
    public void UseObjectSet3() {
        objectSet1.SetActive(false);
        objectSet2.SetActive(false);
        objectSet3.SetActive(true);
        objectSet4.SetActive(false);
    }

    [YarnCommand("UseObjectSet4")]
    public void UseObjectSet4() {
        objectSet1.SetActive(false);
        objectSet2.SetActive(false);
        objectSet3.SetActive(false);
        objectSet4.SetActive(true);
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
        daughterNurse.SetActive(false);
    }

    private void ShowBreakfastPose() {
        grandfather.SetActive(true);
        son.SetActive(false);
        grandson.SetActive(false);
        daughter.SetActive(false);
    }

    private void ShowDaughterAppearPose() {
        daughterNurse.SetActive(true);
    }

    private void ShowDaughterDisappearPose() {
        daughterNurse.SetActive(false);
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
        daughterNurse.SetActive(false);
    }
}
