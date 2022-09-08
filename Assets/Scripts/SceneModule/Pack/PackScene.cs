using System.Collections.Generic;
using Global;
using Global.Base;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities.Event;

namespace SceneModule.Pack
{
    public class PackScene : MonoBehaviour
    {
        [SerializeField] private TMP_Text goldText;
        [SerializeField] private Button backButton;
        [SerializeField] private PackList _packList;
        [SerializeField] private GameObject _popUpView;

        private void Start()
        {
            _packList.SetCallback(SelectPack,ShowPopup);
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(OnCloseButton);
            ChangeCoinText();
        }

        public void SelectPack(string packId)
        {
            SaveData.Instance.SetPackSelectedId(packId);
            SceneManager.LoadScene(Consts.SceneNames.Level);
        }

        private void OnCloseButton()
        {
            SceneManager.LoadScene(Consts.SceneNames.Home);
        }

        private void OnEnable()
        {
            EventManager.StartListening(Consts.EventsName.UnlockPack, UpdateCoin);
        }

        private void OnDisable()
        {
            EventManager.StopListening(Consts.EventsName.UnlockPack, UpdateCoin);
        }

        private void UpdateCoin(Dictionary<string, object> obj)
        {
            ChangeCoinText();
        }

        private void ChangeCoinText()
        {
            goldText.text = SaveData.Instance.gold.ToString();
        }

        private void ShowPopup()
        {
            _popUpView.SetActive(true);
        }
    }
}