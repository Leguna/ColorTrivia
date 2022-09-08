using System;
using System.Collections.Generic;
using Global.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SceneModule.Gameplay.Quiz
{
    class QuizView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _quizText;
        [SerializeField] private Image _image;
        [SerializeField] private Transform _buttonGroup;
        private readonly List<AnswerItemView> _answerItemViews = new();
        private Action<int> _onClickAnswer;

        private LevelStruct _levelStruct;

        public void SetCallback(Action<int> onClickAnswer)
        {
            _onClickAnswer = onClickAnswer;
        }

        private void InitButton()
        {
            var answerButtonPrefab = Resources.Load<AnswerItemView>(Consts.Resources.AnswerButton);
            for (int i = 0; i < 4; i++)
            {
                var answerButton = Instantiate(answerButtonPrefab, _buttonGroup);
                answerButton.buttonNumber = i;
                answerButton.answerButton.onClick.AddListener(() =>
                {
                    _onClickAnswer?.Invoke(answerButton.buttonNumber);
                });
                _answerItemViews.Add(answerButton);
            }
        }

        public void SetData(LevelStruct levelStruct)
        {
            _levelStruct = levelStruct;
            InitButton();
            UpdateView();
        }

        private void UpdateView()
        {
            _quizText.text = _levelStruct.QuizText;
            _image.sprite = _levelStruct.HintImage;
            for (int i = 0; i < _levelStruct.Answers.Length; i++)
            {
                _answerItemViews[i].answerText.text = _levelStruct.Answers[i];
                _answerItemViews[i].image.color = Consts.BaseColors.colors[i];
            }
        }
    }
}