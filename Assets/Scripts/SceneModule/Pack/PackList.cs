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
        private Action _onPackSelect;
        private List<PackData> _packData = new();

        public void SetCallback(Action onPackSelect)
        {
            _onPackSelect = onPackSelect;
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
            SaveData.Instance.packSelectedId = obj.packId;
            SaveData.Instance.Save();
            _onPackSelect?.Invoke();
        }

        private void OnBuyClick(LevelPack obj)
        {
            var isSuccess = _packUnlock?.TryBuyPack(obj) ?? false;
            if (isSuccess)
            {
                UpdateView();
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