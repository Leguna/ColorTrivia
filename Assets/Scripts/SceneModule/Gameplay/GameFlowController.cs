using System;
using Global.Base;
using SceneModule.Gameplay.Countdown;
using SceneModule.Gameplay.Popup;
using SceneModule.Gameplay.Quiz;
using SceneModule.Level;
using UnityEngine;
using Utilities.Event;

namespace SceneModule.Gameplay
{
    public class GameFlowController : MonoBehaviour
    {
        private Action _goToLevelScene;
        private Action _goToPackScene;
        [SerializeField] private PopupController _popupController;
        [SerializeField] private CountdownController _countdownController;
        private LevelDataModel _levelDataModel;
        private QuizController _quizController;

        private void Start()
        {
            _countdownController.SetCallback(Timeout);
        }

        public void SetCallback(Action goToLevelScene, Action goToPackScene)
        {
            _goToLevelScene = goToLevelScene;
            _goToPackScene = goToPackScene;
        }

        public void Timeout()
        {
            _popupController.Show("You Lose!", "");
            _popupController.SetCallbacks(() => _goToLevelScene?.Invoke());
        }

        public void OnAnswerQuestion(int answer)
        {
            if (answer == _levelDataModel.answerIndex)
            {
                EventManager.TriggerEvent(Consts.EventsName.FinishLevel,_levelDataModel.ToDict());
            }
        }
    }
}