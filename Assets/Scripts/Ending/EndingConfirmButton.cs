using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingConfirmButton : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject endingResultPanel = default;
    [SerializeField] private GameObject confirmButton = default;

    public void ShowResults() {
        StartCoroutine(HandleShowResults());
    }

    private IEnumerator HandleShowResults() {
        confirmButton.SetActive(false);

        EndingEffectManager.Instance.BlackenIn(2f);

        yield return new WaitForSeconds(2f);

        endingResultPanel.SetActive(true);
    }
}
