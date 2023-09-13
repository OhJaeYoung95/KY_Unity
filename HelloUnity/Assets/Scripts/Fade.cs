using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Image image;
    private Coroutine coFade;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(coFade != null)
            {
                StopCoroutine(coFade);
            }
            coFade = StartCoroutine(CoFade(image.color, Color.clear, 2f));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (coFade != null)
            {
                StopCoroutine(coFade);
            }
            coFade = StartCoroutine(CoFade(image.color, Color.black, 2f));
        }
    }

    IEnumerator CoFade(Color startColor, Color endColor, float duration)
    {
        image.enabled = true;
        float time = 0f;
        image.color = startColor;
        while (time < duration)
        {
            time += Time.deltaTime;
            if (time > duration)
                time = duration;
            image.color = Color.Lerp(startColor, endColor, time / duration);
            yield return null;
        }
        coFade = null;
    }
}
