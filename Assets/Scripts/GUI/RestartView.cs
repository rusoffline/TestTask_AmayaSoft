using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.UI
{
    public class RestartView : FadeableBase, IRestartView
    {
        [SerializeField]
        private Button restartButton;

        public Button RestartButton => restartButton;

        public void Hide(float duration)
        {
            Fade(0f, duration);
        }

        public void AddListenerOnRestart(UnityAction restartAction)
        {
            restartButton.onClick.AddListener(restartAction);
        }

        public void Show(float duration)
        {
            Fade(1f, duration);
        }
    }
}
