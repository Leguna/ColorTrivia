using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SceneModule.Gameplay.Popup
{
    public class PopupController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _desc;
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

        public void Show(string title, string desc)
        {
            gameObject.SetActive(true);
            _title.text = title;
            _desc.text = desc;
        }


        public void SetCallbacks(Action onClosePopup)
        {
            _onPopupClose = onClosePopup;
        }
    }
}