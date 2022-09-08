using System;
using System.Collections.Generic;
using System.Linq;
using Global.Base;
using UnityEngine;

namespace Global
{
    [Serializable]
    public class Database : MonoBehaviour
    {
        public List<LevelPack> levelPacks;

        private void Awake()
        {
            levelPacks = Resources.LoadAll<LevelPack>(Consts.Resources.LevelPackPath).ToList();
        }

        public LevelPack GetLevelPackById(string id)
        {
            return levelPacks.FirstOrDefault(x => x.packId == id);
        }
    }
}