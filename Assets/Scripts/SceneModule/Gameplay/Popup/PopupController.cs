using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SceneModule.Gameplay.Popup
{
    public class PopupController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Button _popUpButton;

        private Action _onPopupClose;

        private void Start()
        {
            _popUpButton.onClick.RemoveAllListeners();
            _popUpButton.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
                _onPopupClose?.Invoke();
            });
        }

        public void Show(string title)
        {
            gameObject.SetActive(true);
            _title.text = title;
        }


        public void SetCallbacks(Action onClosePopup)
        {
            _onPopupClose = onClosePopup;
        }
    }
}