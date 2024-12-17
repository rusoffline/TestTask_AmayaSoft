namespace Game.Controllers
{
    public class GameFlowController
    {
        private readonly ILevelController levelController;
        private readonly IRestartView restartView;
        private readonly IFadeView fadeView;

        private int currentLevel;

        public GameFlowController(ILevelController levelController, IRestartView restartView, IFadeView fadeView)
        {
            this.levelController = levelController;
            this.restartView = restartView;
            this.fadeView = fadeView;

            this.levelController.AddLevelCompletedListener(() => TryLevelUp());
            restartView.AddListenerOnRestart(() => RestartGame());
        }

        public void StartGame()
        {
            RestartGame();
        }

        private void RestartGame()
        {
            currentLevel = 0;
            levelController.LoadLevel(currentLevel);
            fadeView.FadeIn(0.5f);
            restartView.Hide(0.5f);

            levelController.FieldController.LockCells(false);
        }

        public void TryLevelUp()
        {
            currentLevel++;
            if (levelController.IsLastLevel(currentLevel))
            {
                EndGame();
            }
            else
            {
                levelController.LoadLevel(currentLevel);
            }
        }

        private void EndGame()
        {
            fadeView.FadeOut(0.5f);
            restartView.Show(0.5f);

            levelController.FieldController.LockCells(true);
        }
    }
}
