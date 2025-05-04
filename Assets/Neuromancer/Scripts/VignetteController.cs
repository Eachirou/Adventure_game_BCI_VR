using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VignetteController : MonoBehaviour
{
    public Image image;
    public float fadeDelay = 1f;

    public void Vignette()
    {
        FadeIn();

        Invoke("FadeOut", 2f);
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(true));
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(false));
    }

    IEnumerator Fade(bool fadeIn)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < fadeDelay)
        {
            yield return null;
            elapsedTime += Time.deltaTime;
            if (fadeIn)
            {
                c.a = Mathf.Clamp01(elapsedTime / fadeDelay);
            }
            else
            {
                c.a = 1f - Mathf.Clamp01(elapsedTime / fadeDelay);
            }

            image.color = c;
        }
    }
}
