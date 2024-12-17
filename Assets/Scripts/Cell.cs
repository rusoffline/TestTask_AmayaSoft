using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Cell : MonoBehaviour//cell interface?
{
    [SerializeField]
    private SpriteRenderer spriteRender;
    private CardData cardData;
    public CardData CardData => cardData;
    private bool isLocked;

    //Как отрабывать кликер? через action или через инверсю зависимости?
    private UnityAction<Cell> onClick;

    public void Initialize(CardData cardData, UnityAction<Cell> onClick)
    {
        this.cardData = cardData;
        spriteRender.sprite = this.cardData.Sprite;
        spriteRender.transform.localEulerAngles = new Vector3(0, 0, this.cardData.Angle);

        this.onClick = onClick;
    }

    private void OnMouseDown()
    {
        if (isLocked)
            return;

        Debug.Log($"Clicked {cardData.Identifier}");
        onClick?.Invoke(this);
    }

    public void ReactToClick(bool isCorrect, float duration)
    {
        if (isCorrect)
        {
            Debug.Log("Is correct!");
            PlayBounceScaleEffect(duration);
        }
        else
        {
            Debug.Log("Is not correct!");
            PlayLeftRightBounceEffect(duration);
        }
    }

    private void PlayBounceScaleEffect(float duration)
    {
        transform.DOKill();
        transform.DOScale(Vector3.one * 1.2f, duration / 2)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
                transform.DOScale(Vector3.one, duration / 2)
                    .SetEase(Ease.OutBounce));
    }

    private void PlayLeftRightBounceEffect(float duration)
    {
        transform.DOKill();
        float distance = 0.5f;
        transform.DOMoveX(transform.position.x - distance, duration / 2)
            .SetEase(Ease.InBounce)
            .SetLoops(2, LoopType.Yoyo);
    }

    public void PlayeApperEffect(float duration)
    {
        PlayBounceScaleEffect(duration);
    }

    public void SetCellLocked(bool isLocked)
    {
        this.isLocked = isLocked;
    }
}
