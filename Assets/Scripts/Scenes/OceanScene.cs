using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class OceanScene : Scene
{
    [Header("Poses")]
    [SerializeField] private GameObject handRaise = default;

    public override void ToggleActive(bool state) {
        rootCanvas.SetActive(state);

        if(state) ResetPoses();
    }

    [YarnCommand("ShowPose")]
    public override void ShowPose(string pose) {
        switch(pose) {
            case "HANDRAISE":
                ShowHandRaisePose();
                break;
            default:
                ThrowUnknownPoseError(pose, type);
                break;
        }
    }

    private void ShowHandRaisePose() {
        handRaise.SetActive(true);
    }

    public override void ResetPoses() {
        handRaise.SetActive(false);
    }
}
