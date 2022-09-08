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
        public Texture2D imageHint;
        public List<Answer> answers;
        public int answerIndex;
        public bool isCompleted;

        public Dictionary<string, object> ToDict()
        {
            return new Dictionary<string, object> { { "LevelID", levelId } };
        }

        public static LevelDataModel FromDict(Dictionary<string, object> data)
        {
            var levelId = data["LevelID"].ToString();
            return JsonUtility.FromJson<LevelDataModel>(levelId);
        }
    }
}