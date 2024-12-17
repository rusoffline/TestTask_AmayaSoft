using System.Threading.Tasks;
using UnityEngine.Events;

namespace Game.Controllers
{
    public class LevelController : ILevelController
    {
        private readonly GameData gameData;
        private readonly ICardController cardController;
        private readonly IQuestionView questionView;
        private readonly IFieldController fieldController;
        private readonly IParticleEffect particleEffect;
        private UnityAction onLevelCompleted;
        private CardData correctCard;
        private bool isPorcessing;

        public IFieldController FieldController => fieldController;

        public LevelController(ICardController cardController, GameData gameData, IQuestionView questionView, IFieldController fieldController, IParticleEffect particleEffect)
        {
            this.cardController = cardController;
            this.gameData = gameData;
            this.questionView = questionView;
            this.fieldController = fieldController;
            this.particleEffect = particleEffect;
        }

        public void LoadLevel(int levelIndex)
        {
            Level levelData = gameData.Level[levelIndex];
            var answerCards = cardController.GetRandomCardsWithUnique(levelData, gameData.Cards, out correctCard);

            questionView.UpdateQuestion(correctCard);
            fieldController.CreateField(answerCards, levelData, HandleCellClick);

            if (levelIndex == 0)
            {
                fieldController.AnimateFieldCells(.5f);
            }
        }

        public bool IsLastLevel(int levelIndex)
        {
            return levelIndex >= gameData.Level.Length;
        }

        private async void HandleCellClick(Cell clickedCell)
        {
            if (isPorcessing)
                return;

            isPorcessing = true;

            bool isCorrect = clickedCell.CardData == correctCard;
            clickedCell.ReactToClick(isCorrect, 0.5f);

            if (isCorrect)
            {
                particleEffect.PlayAt(clickedCell.transform.position);
                await Task.Delay(500);
                onLevelCompleted?.Invoke();
            }

            isPorcessing = false;
        }

        public void AddLevelCompletedListener(UnityAction subscribe)
        {
            onLevelCompleted += subscribe;
        }
    }
}
