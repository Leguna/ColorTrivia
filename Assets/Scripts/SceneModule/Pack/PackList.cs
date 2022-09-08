using System;
using System.Collections.Generic;
using System.Linq;
using Global;
using Global.Base;
using UnityEngine;

namespace SceneModule.Pack
{
    public class PackList : MonoBehaviour
    {
        [SerializeField] private Transform _levelGroupTransform;
        private readonly PackUnlock _packUnlock = new();
        private Action<string> _onPackSelect;
        private List<PackData> _packData = new();
        private Action _showPopup;

        public void SetCallback(Action<string> onPackSelect, Action showPopup)
        {
            _onPackSelect = onPackSelect;
            _showPopup = showPopup;
        }

        private void Start()
        {
            SpawnLevelSelect();
        }

        public void SpawnLevelSelect()
        {
            var levelPacks = Resources.LoadAll<LevelPack>(Consts.Resources.LevelPackPath).ToList();
            var levelPackItemPrefab = Resources.Load<PackData>(Consts.Resources.LevelPackItemPrefab);
            foreach (var levelPack in levelPacks)
            {
                var levelPackItem = Instantiate(levelPackItemPrefab, _levelGroupTransform);
                levelPackItem.Setup(levelPack);
                levelPackItem.SetCallbacks(OnPackClick, OnBuyClick);
                _packData.Add(levelPackItem);
            }
        }

        private void OnPackClick(LevelPack obj)
        {
            _onPackSelect?.Invoke(obj.packId);
        }

        private void OnBuyClick(LevelPack obj)
        {
            var isSuccess = _packUnlock?.TryBuyPack(obj) ?? false;
            if (isSuccess)
            {
                UpdateView();
            }
            else
            {
                _showPopup?.Invoke();
            }
        }

        private void UpdateView()
        {
            foreach (var packData in _packData)
            {
                packData.UpdateView();
            }
        }
    }
}