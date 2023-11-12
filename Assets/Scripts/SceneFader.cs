using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneFader : MonoBehaviour
{
    public Image image;                                 //darkness that scene 'fades' to
    public AnimationCurve curve;                        //alpha of color changes
    void Start()
    {
        StartCoroutine(FadeIn());                       //starts fading
    }
    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));                 //fades to scene
    }
    IEnumerator FadeIn()                                //time it takes to fade to alpha color
    {
        float t = 1f;
        while(t>0f)
        {
            t -= Time.deltaTime * 1.3f;
            float a = curve.Evaluate(t);
            image.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }
    IEnumerator FadeOut(string scene)                   //time it takes to fade out of alpha color
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 1.3f;
            float a = curve.Evaluate(t);
            image.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        SceneManager.LoadScene(scene);                  //loads to next scene
    }
}
