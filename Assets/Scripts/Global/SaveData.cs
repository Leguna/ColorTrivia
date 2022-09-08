using System;
using System.Collections.Generic;
using System.Linq;
using Global.Base;
using SceneModule.Level;
using UnityEngine;
using Utilities;
using Utilities.Event;

namespace Global
{
    [Serializable]
    public class SaveData : SingletonMonoBehaviour<SaveData>
    {
        private const int VersionNumber = 1;
        private string _databaseKey = $"PlayerData_{VersionNumber}";

        public int gold;
        public Database database;
        public BoughtPack boughtPack = new();
        public CompletedLevel completedLevel = new();
        [SerializeField] private Currency _currency;
        public string PackSelectedId { get; private set; } = "A";
        public string LevelDataSelectedId { get; private set; } = "A1";

        protected override void Awake()
        {
            base.Awake();
            TryGetComponent(out database);
            TryGetComponent(out _currency);
            Load();
        }

        public void SetPackSelectedId(string id)
        {
            PackSelectedId = id;
            Save();
        }

        public void SetLevelDataSelectedId(string id)
        {
            LevelDataSelectedId = id;
            Save();
        }

        private void OnEnable()
        {
            EventManager.StartListening(Consts.EventsName.UnlockPack, _ => Save());
            EventManager.StartListening(Consts.EventsName.FinishLevel, _ =>
            {
                LevelUnlock();
                Save();
            });
        }

        private void OnDisable()
        {
            EventManager.StopListening(Consts.EventsName.UnlockPack, _ => Save());
            EventManager.StopListening(Consts.EventsName.FinishLevel, _ => Save());
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
                PackSelectedId = "A";
                LevelDataSelectedId = "A1";
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
            return levelPack.listLevelDataIds.items.All(levelData => completedLevel.items.Contains(levelData));
        }

        public bool IsAllLevelCompleted()
        {
            return database.GetLevelPackById(PackSelectedId ?? "A").listLevelDataIds.items
                .All(levelData => completedLevel.items.Contains(levelData));
        }


        public bool IsLevelCompleted(string dataLevelId)
        {
            return completedLevel.items.Contains(dataLevelId);
        }

        public LevelDataModel GetCurrentLevelData()
        {
            return database.GetLevelDataModelById(LevelDataSelectedId ?? "A1");
        }

        public void LevelUnlock()
        {
            if (completedLevel.items.Contains(LevelDataSelectedId)) return;
            _currency.AddCurrency(database.GetLevelDataModelById(LevelDataSelectedId).ToDict());
            completedLevel.items.Add(LevelDataSelectedId);
            Save();
        }

        public void NextLevel()
        {
            var pack = database.GetLevelPackById(PackSelectedId);
            var indexLevel = pack.listLevelDataIds.items.IndexOf(LevelDataSelectedId);
            if (indexLevel + 1 < pack.listLevelDataIds.items.Count)
            {
                LevelDataSelectedId = pack.listLevelDataIds.items[indexLevel + 1];
            }
            else
            {
                foreach (var item in pack.listLevelDataIds.items)
                {
                    if (completedLevel.items.Contains(item)) continue;
                    LevelDataSelectedId = item;
                    break;
                }
            }
        }
    }
}