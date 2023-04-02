using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] private float duration = 1.0f;
    private CanvasGroup group; 
    private Button btn;

    //Äµ¹ö½º 
    public void FadeIn(CanvasGroup _group, float _duration)
    {
        duration = _duration;
        group = _group;
        StartCoroutine(FadeCanvasGroup(group, group.alpha, 1f, duration));
    }

    public void FadeOut(CanvasGroup _group, float _duration)
    {
        duration = _duration;
        group = _group;
        StartCoroutine(FadeCanvasGroup(group, group.alpha, 0f, duration));
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup _group, float start, float end, float _duration)
    {
        float time = 0f;
        duration = _duration;
        group = _group;
        while (time < duration)
        {
            group.alpha = Mathf.Lerp(start, end, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        group.alpha = end;
    }

}
