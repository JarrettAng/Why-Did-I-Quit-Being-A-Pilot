using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class EffectManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DialogueRunner dialogueRunner = default;
    [SerializeField] private GameObject blackenPanel = default;
    [SerializeField] private GameObject dimPanel = default;

    [Header("Read-Only")]
    [SerializeField] private Color blackenPanelColor = Color.black;

    private Image blackenPanelImage;
    private Image dimPanelImage;

    private void Awake() {
        blackenPanelImage = blackenPanel.GetComponent<Image>();
        dimPanelImage = dimPanel.GetComponent<Image>();

        InitializeYarnCommands();

        void InitializeYarnCommands() {
            dialogueRunner.AddCommandHandler (
                "BlackenIn",
                BlackenIn
            );

            dialogueRunner.AddCommandHandler(
                "BlackenOut",
                BlackenOut
            );
        }
    }

    public void BlackenIn(string[] transitionTimeString, System.Action onComplete) {
        float transitionTime = float.Parse(transitionTimeString[1], CultureInfo.InvariantCulture.NumberFormat);

        StartCoroutine(BlackenInTransition());

        IEnumerator BlackenInTransition() {
            ToggleBlackenPanel(true);

            float step = (1f / transitionTime) * Time.fixedDeltaTime;

            blackenPanelColor.a = 0;
            while(blackenPanelImage.color.a < 1) {
                blackenPanelColor.a += step;
                blackenPanelImage.color = blackenPanelColor;

                yield return new WaitForFixedUpdate();
            }

            onComplete();
        }
    }

    public void BlackenOut(string[] transitionTimeString /*, System.Action onComplete*/) {
        float transitionTime = float.Parse(transitionTimeString[1], CultureInfo.InvariantCulture.NumberFormat);

        StartCoroutine(BlackenOutTransition());

        IEnumerator BlackenOutTransition() {
            float step = (1f / transitionTime) * Time.fixedDeltaTime;

            blackenPanelColor.a = 1;
            while(blackenPanelImage.color.a > 0) {
                blackenPanelColor.a -= step;
                blackenPanelImage.color = blackenPanelColor;

                yield return new WaitForFixedUpdate();
            }

            ToggleBlackenPanel(false);

            // onComplete();
        }
    }

    private void ToggleBlackenPanel(bool state) {
        blackenPanel.SetActive(state);
    }

    //public void DimIn(float transitionTime) { 
    
    //}

    //public void DimOut(float transitionTime) {

    //}
}
