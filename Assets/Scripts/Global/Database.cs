using System;
using System.Collections.Generic;
using System.Linq;
using Global.Base;
using SceneModule.Level;
using UnityEngine;

namespace Global
{
    [Serializable]
    public class Database : MonoBehaviour
    {
        public List<LevelPack> levelPacks;
        public List<LevelDataModel> levelDataModels;

        private void Awake()
        {
            levelPacks = Resources.LoadAll<LevelPack>(Consts.Resources.LevelPackPath).ToList();
            levelDataModels = Resources.LoadAll<LevelDataModel>(Consts.Resources.LevelData).ToList();
        }

        public LevelPack GetLevelPackById(string id)
        {
            return levelPacks.FirstOrDefault(x => x.packId == id);
        }

        public LevelDataModel GetLevelDataModelById(string id)
        {
            return levelDataModels.FirstOrDefault(x => x.levelId == id);
        }
    }
}