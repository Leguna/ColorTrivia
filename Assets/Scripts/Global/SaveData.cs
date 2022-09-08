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
        [NonSerialized] public Database database;
        [HideInInspector] public BoughtPack boughtPack = new();
        [HideInInspector] public CompletedLevel completedLevel = new();
        [HideInInspector] public string packSelectedId;
        [HideInInspector] public string levelDataSelectedId;

        protected override void Awake()
        {
            base.Awake();
            TryGetComponent(out database);
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
                    { items = new List<string> { Resources.Load<LevelPack>(Consts.Resources.FirstLevelPack).packId } };
                Save();
            }

            return this;
        }

        public bool IsAlreadyBoughtPack(LevelPack levelPack)
        {
            return boughtPack.items.Contains(levelPack.packId);
        }

        public bool IsAllLevelCompleted(LevelPack levelPack)
        {
            return levelPack.listLevelDataIds.All(levelData => completedLevel.items.Contains(levelData));
        }
    }
}