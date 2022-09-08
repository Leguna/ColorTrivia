using System;
using System.Linq;
using Global.Base;
using UnityEngine;

namespace SceneModule.SelectPack
{
    public class LevelSelection : MonoBehaviour
    {
        [SerializeField] private Transform _levelGroupTransform;
        private Action _onPackSelect;


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
            var levelPackItemPrefab = Resources.Load<LevelPackItem>(Consts.Resources.LevelPackItemPrefab);
            foreach (var levelPack in levelPacks)
            {
                var levelPackItem = Instantiate(levelPackItemPrefab, _levelGroupTransform);
                levelPackItem.Setup(levelPack);
            }
        }
    }
}