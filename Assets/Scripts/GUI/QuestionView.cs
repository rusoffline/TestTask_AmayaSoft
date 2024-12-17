using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class QuestionView : FadeableBase, IQuestionView
    {
        [SerializeField]
        private TMP_Text questionText;

        public void UpdateQuestion(CardData cardData)
        {
            //questionText.text = $"Find {cardData.Identifier.ToUpper()}";
            //FadeOut(.5f);
            AnimateQuest(cardData);
        }
        private async void AnimateQuest(CardData cardData) 
        {
            FadeIn(.5f);
            await Task.Delay(500);
            questionText.text = $"Find {cardData.Identifier.ToUpper()}";
            FadeOut(.5f);
        }

    }
}
