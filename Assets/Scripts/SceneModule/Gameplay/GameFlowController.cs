using System;
using Global;
using Global.Base;
using SceneModule.Gameplay.Countdown;
using SceneModule.Gameplay.Popup;
using SceneModule.Gameplay.Quiz;
using SceneModule.Level;
using TMPro;
using UnityEngine;
using Utilities.Event;

namespace SceneModule.Gameplay
{
    public class GameFlowController : MonoBehaviour
    {
        private Action _goToLevelScene;
        private Action _goToNextLevel;
        [SerializeField] private PopupController _popupController;
        [SerializeField] private CountdownController _countdownController;
        [SerializeField] private QuizController _quizController;
        [SerializeField] private TMP_Text _levelText;
        private LevelDataModel _levelDataModel;

        private void Start()
        {
            _countdownController.SetCallback(Timeout);
            _levelDataModel = SaveData.Instance.GetCurrentLevelData();
            _levelText.text = _levelDataModel.name;
            _quizController.InitQuiz(new LevelStruct(_levelDataModel.imageHint, _levelDataModel.answers.ToArray(),
                _levelDataModel.questionText));
            _quizController.SetCallbacks(OnAnswerQuestion);
        }

        public void SetCallback(Action goToLevelScene, Action goToNextLevel)
        {
            _goToLevelScene = goToLevelScene;
            _goToNextLevel = goToNextLevel;
        }

        public void Timeout()
        {
            Lost();
        }

        private void Lost()
        {
            _countdownController.StopCountdown();
            _popupController.Show("You Lost!");
            _popupController.SetCallbacks(() => _goToLevelScene?.Invoke());
        }

        public void OnAnswerQuestion(int answer)
        {
            if (answer == _levelDataModel.answerIndex)
            {
                Win();
            }
            else
            {
                Lost();
            }
        }

        private void Win()
        {
            EventManager.TriggerEvent(Consts.EventsName.FinishLevel, _levelDataModel.ToDict());
            _countdownController.StopCountdown();
            _popupController.Show("You Win!");
            _popupController.SetCallbacks(() => { _goToNextLevel?.Invoke(); });
        }
    }
}