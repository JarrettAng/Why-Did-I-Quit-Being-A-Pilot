using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingEffectManager : Singleton<EndingEffectManager>
{
    [Header("References")]
    [SerializeField] private GameObject blackenPanel = default;

    [Header("Read-Only")]
    [SerializeField] private Color blackenPanelColor = Color.black;

    private Image blackenPanelImage;

    private void Awake() {
        blackenPanelImage = blackenPanel.GetComponent<Image>();
    }

    public void BlackenIn(float seconds) {
        StartCoroutine(BlackenInTransition());

        IEnumerator BlackenInTransition() {
            ToggleBlackenPanel(true);

            float step = (1f / seconds) * Time.fixedDeltaTime;

            blackenPanelColor.a = 0;
            while(blackenPanelImage.color.a < 1) {
                blackenPanelColor.a += step;
                blackenPanelImage.color = blackenPanelColor;

                yield return new WaitForFixedUpdate();
            }
        }
    }

    public void BlackenOut(float seconds) {
        StartCoroutine(BlackenOutTransition());

        IEnumerator BlackenOutTransition() {
            ToggleBlackenPanel(true);

            float step = (1f / seconds) * Time.fixedDeltaTime;

            Debug.Log(step);

            blackenPanelColor.a = 1;
            while(blackenPanelImage.color.a > 0) {
                blackenPanelColor.a -= step;
                blackenPanelImage.color = blackenPanelColor;

                yield return new WaitForFixedUpdate();
            }

            ToggleBlackenPanel(false);
        }
    }

    private void ToggleBlackenPanel(bool state) {
        blackenPanel.SetActive(state);
    }
}
