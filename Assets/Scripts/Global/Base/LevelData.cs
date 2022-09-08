using System.Collections.Generic;
using UnityEngine;

namespace Global.Base
{
    [CreateAssetMenu(fileName = "LevelData_", menuName = "LevelData")]
    public class LevelData : ScriptableObject
    {
        public new string name = "";
        public string questionText;
        public Texture2D imageHint;
        public List<Answer> answers;
        public int answerIndex;
    }
}