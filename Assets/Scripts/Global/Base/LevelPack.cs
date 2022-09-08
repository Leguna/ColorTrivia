using System.Collections.Generic;
using UnityEngine;

namespace Global.Base
{
    [CreateAssetMenu(fileName = "LevelPack_", menuName = "LevelPack", order = 0)]
    public class LevelPack : ScriptableObject
    {
        public string packId;
        public string packName;
        public int price = 100;
        public List<string> listLevelDataIds;

        public Dictionary<string, object> ToJson()
        {
            var data = JsonUtility.ToJson(this);
            return new Dictionary<string, object>() { { "LevelPack", data } };
        }

        public static LevelPack FromJson(Dictionary<string, object> data)
        {
            var json = data["LevelPack"].ToString();
            return JsonUtility.FromJson<LevelPack>(json);
        }
    }
}