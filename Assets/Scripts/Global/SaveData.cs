using System;
using System.Collections.Generic;
using System.Linq;
using Global.Base;
using UnityEngine;
using Utilities;

namespace Global
{
    [Serializable]
    public class SaveData : SingletonMonoBehaviour<SaveData>
    {
        private const int VersionNumber = 1;
        private string _databaseKey = $"PlayerData_{VersionNumber}";

        public int gold;

        [HideInInspector] public LevelPackDatabase levelPackDatabase = new();
        public BoughtPack boughtPack = new();
        public CompletedLevel completedLevel = new();
        [HideInInspector] public LevelPack packSelected;
        [HideInInspector] public LevelData levelDataSelected;

        protected override void Awake()
        {
            base.Awake();
            levelPackDatabase.levelPacks = Resources.LoadAll<LevelPack>(Consts.Resources.LevelPackPath).ToList();
            Load();
        }

        public void Save()
        {
            var jsonGameConfig = JsonUtility.ToJson(this);
            PlayerPrefs.SetString(_databaseKey, jsonGameConfig);
            PlayerPrefs.Save();
        }

        public SaveData Load()
        {
            var jsonGameConfig = PlayerPrefs.GetString(_databaseKey);
            if (!string.IsNullOrEmpty(jsonGameConfig))
            {
                JsonUtility.FromJsonOverwrite(jsonGameConfig, this);
            }
            else
            {
                Resources.Load<LevelPack>(Consts.Resources.FirstLevelPack);
                gold = 0;
                boughtPack = new BoughtPack
                    { items = new List<LevelPack> { Resources.Load<LevelPack>(Consts.Resources.FirstLevelPack) } };
                Save();
            }

            return this;
        }

        public bool IsAlreadyBoughtPack(LevelPack levelPack)
        {
            return boughtPack.items.Contains(levelPack);
        }

        public bool IsAllLevelCompleted(LevelPack levelPack)
        {
            return levelPack.listLevelData.All(levelData => completedLevel.items.Contains(levelData));
        }
    }
}