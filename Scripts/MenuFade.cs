using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFade : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float delayBeforeFading = 3.5f;
    public float fadeInDuration = 1.2f;

    void Start()
    {
        StartCoroutine(FadeInMenu());
    }

    IEnumerator FadeInMenu()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        yield return new WaitForSeconds(delayBeforeFading);

        float elapsedTime = 0;
        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = elapsedTime / fadeInDuration;
            yield return null;
        }

        canvasGroup.alpha = 1;
    }
}

