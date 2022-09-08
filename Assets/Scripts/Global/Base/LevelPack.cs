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
        public ListID listLevelDataIds = new();

        public Dictionary<string, object> ToDict()
        {
            return new Dictionary<string, object>() { { "PackID", packId } };
        }

        public static string FromDict(Dictionary<string, object> data)
        {
            return data["PackID"].ToString();
        }
    }
}