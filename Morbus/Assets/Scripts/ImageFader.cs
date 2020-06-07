using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFader : MonoBehaviour
{
    [SerializeField] bool fadeOut = true;

    GameManager GM;


    private void Start()
    {
        if (fadeOut)
        {
            StartCoroutine(FadeTextToZeroAlpha(5f, GetComponent<Image>()));
        }
        else
        {
            StartCoroutine(FadeTextToFullAlpha(6f, GetComponent<Image>()));
        }

    }



    public IEnumerator FadeTextToFullAlpha(float t, Image i)
    {

        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);

        yield return new WaitForSeconds(4);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }

        yield return new WaitForSeconds(4);
        GameManager.GM.GoToMenu();
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Image i)
    {
        yield return new WaitForSeconds(1);
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        yield return new WaitForSeconds(3);
    }
}
