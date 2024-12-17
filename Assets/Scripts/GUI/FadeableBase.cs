using UnityEngine;
using DG.Tweening;

public abstract class FadeableBase : MonoBehaviour, IFadeable
{
    [SerializeField]
    private CanvasGroup canvasGroup;

    public void FadeOut(float duration)
    {
        Fade(1f, duration);
    }

    public void FadeIn(float duration)
    {
        Fade(0f, duration);
    }

    protected void Fade(float endValue, float duration)
    {
        if (canvasGroup != null)
        {
            canvasGroup.DOKill();
            canvasGroup.DOFade(endValue, duration);

            canvasGroup.blocksRaycasts = endValue > 0.5f;

        }
    }
}
