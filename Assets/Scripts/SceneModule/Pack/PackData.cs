using System;
using Global;
using Global.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SceneModule.Pack
{
    public class PackData : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelPackName;
        [SerializeField] private GameObject _checkMark;
        [SerializeField] private GameObject _lockParent;
        [SerializeField] private TMP_Text _packPrice;
        [SerializeField] private Button _packButton;
        [SerializeField] private Button _buyButton;
        private LevelPack _levelPack;

        public void Setup(LevelPack levelPack)
        {
            _levelPack = levelPack;
            UpdateView();
        }

        public void SetCallbacks(Action<LevelPack> onPackClick, Action<LevelPack> onBuyClick)
        {
            _packButton.onClick.RemoveAllListeners();
            _buyButton.onClick.RemoveAllListeners();
            _packButton.onClick.AddListener(() => onPackClick?.Invoke(_levelPack));
            _buyButton.onClick.AddListener(() => onBuyClick?.Invoke(_levelPack));
        }

        public void UpdateView()
        {
            _levelPackName.text = _levelPack.packName;
            _packPrice.text = _levelPack.price.ToString();
            SetCheckMark();
            SetLock();
        }

        private void SetCheckMark()
        {
            var isAllLevelCompleted = SaveData.Instance.IsAllLevelCompleted(_levelPack);
            _checkMark.SetActive(isAllLevelCompleted);
        }

        private void SetLock()
        {
            var isAlreadyBoughtPack = SaveData.Instance.IsAlreadyBoughtPack(_levelPack);
            _packButton.interactable = isAlreadyBoughtPack;
            _lockParent.SetActive(!isAlreadyBoughtPack);
        }
    }
}