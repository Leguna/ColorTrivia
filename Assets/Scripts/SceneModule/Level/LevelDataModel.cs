using System.Collections.Generic;
using Global.Base;
using UnityEngine;

namespace SceneModule.Level
{
    [CreateAssetMenu(fileName = "Level_", menuName = "Level")]
    public class LevelDataModel : ScriptableObject
    {
        public string levelId;
        public new string name = "";
        public string questionText;
        public Sprite imageHint;
        public List<string> answers;
        public int answerIndex;
        public bool isCompleted;

        public Dictionary<string, object> ToDict()
        {
            return new Dictionary<string, object> { { "LevelID", levelId } };
        }

        public static string FromDict(Dictionary<string, object> data)
        {
            return data["LevelID"].ToString();
        }
    }
}