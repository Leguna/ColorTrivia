using System;
using Global.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SceneModule.Gameplay.Countdown
{
    public class CountdownController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private Slider _slider;

        private const float Time = Consts.GameConstant.Timer;
        private float _currentTime;
        private Action _onTimerFinish;
        private bool _isCounting = true;

        private void Start()
        {
            StartCountDown();
        }

        public void OnTick()
        {
            if (!_isCounting) return;
            _currentTime -= 1;

            _timerText.text = $"{_currentTime:##.0}s";
            _slider.value = _currentTime / Time;

            if (!(_currentTime <= 0)) return;
            FinishCountdown();
        }

        public void StopCountdown()
        {
            _isCounting = false;
            CancelInvoke(nameof(OnTick));
        }

        public void FinishCountdown()
        {
            _onTimerFinish?.Invoke();
            StopCountdown();
        }

        public void SetCallback(Action onTimeOver)
        {
            _onTimerFinish = onTimeOver;
        }

        public void StartCountDown()
        {
            _currentTime = Time;
            InvokeRepeating(nameof(OnTick), 0, 1);
        }
    }
}