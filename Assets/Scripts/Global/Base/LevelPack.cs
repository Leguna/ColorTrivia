using System.Collections.Generic;
using UnityEngine;

namespace Global.Base
{
    [CreateAssetMenu(fileName = "LevelPack_", menuName = "LevelPack", order = 0)]
    public class LevelPack : ScriptableObject
    {
        public string packName;
        public int price = 100;
        public List<LevelData> listLevelData;
    }
}