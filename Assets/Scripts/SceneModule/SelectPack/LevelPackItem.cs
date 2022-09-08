using Global;
using Global.Base;
using TMPro;
using UnityEngine;

namespace SceneModule.SelectPack
{
    public class LevelPackItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelPackName;
        [SerializeField] private GameObject _checkMark;
        [SerializeField] private GameObject _lockParent;
        [SerializeField] private TMP_Text _packPrice;
        private LevelPack _levelPack;

        public void Setup(LevelPack levelPack)
        {
            _levelPack = levelPack;
            UpdateView();
        }

        public void UpdateView()
        {
            _levelPackName.text = _levelPack.packName;
        }

        private void SetCheckMark()
        {
            SaveData.Instance.IsAllLevelCompleted(_levelPack);
        }

        private void SetLock()
        {
            var contains = SaveData.Instance.IsAlreadyBoughtPack(_levelPack);
            _lockParent.SetActive(contains);
        }
    }
}