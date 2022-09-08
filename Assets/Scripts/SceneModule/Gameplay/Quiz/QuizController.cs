using System;
using Global.Base;
using UnityEngine;

namespace SceneModule.Gameplay.Quiz
{
    public class QuizController : MonoBehaviour
    {
        [SerializeField] private QuizView _quizView;

        public void InitQuiz(LevelStruct levelStruct)
        {
            _quizView.SetData(levelStruct);
        }

        public void SetCallbacks(Action<int> onClickAnswer)
        {
            _quizView.SetCallback(onClickAnswer);
        }
    }
}