using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fader : MonoBehaviour
{
    [SerializeField] bool fadeOut = true;

    GameManager GM;


    private void Start()
    {
        if (fadeOut)
        {
            StartCoroutine(FadeTextToZeroAlpha(5f, GetComponent<Text>()));
        }
        else
        {
            StartCoroutine(FadeTextToFullAlpha(5f, GetComponent<Text>()));
        }
       
    }



    public IEnumerator FadeTextToFullAlpha(float t, Text i)
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

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        yield return new WaitForSeconds(3);
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}