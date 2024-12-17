using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game.UI;
using Game.Controllers;

public class GameStartup : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private FadeView fadeView;
    [SerializeField] private RestartView restartView;
    [SerializeField] private QuestionView questionView;
    [SerializeField] private FieldController fieldController;
    [SerializeField] private ParticleEffect particleEffect;

    private void Start()
    {
        //var cardController = new QuestCardController();
        var cardController = new RandomQuestCardController();
        var levelController = new LevelController(cardController, gameData, questionView, fieldController, particleEffect);
        var gameFlowController = new GameFlowController(levelController, restartView, fadeView);

        gameFlowController.StartGame();
    }
}
