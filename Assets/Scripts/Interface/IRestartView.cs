using UnityEngine.Events;

public interface IRestartView
{
    void AddListenerOnRestart(UnityAction subscribe);
    void Hide(float duration);
    void Show(float duration);
}
