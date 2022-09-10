using System.Collections.Generic;
using UnityEngine;

namespace Global.Base
{
    internal static class Consts
    {
        public static class SceneNames
        {
            public const string Home = "Home";
            public const string Pack = "Pack";
            public const string Level = "Level";
            public const string Gameplay = "Gameplay";
        }

        public static class GameConstant
        {
            public const int Timer = 10;
            public const int RewardGold = 20;
        }

        public static class Resources
        {
            public const string FirstLevelPack = "LevelPack/LevelPack_A";
            public const string LevelPackPath = "LevelPack/";
            public const string LevelPackItemPrefab = "Prefabs/PackItem";
            public const string LevelData = "LevelData/";
            public const string LevelDataView = "Prefabs/LevelDataView";
            public const string AnswerButton = "Prefabs/AnswerItem";
        }

        public static class EventsName
        {
            public const string UnlockPack = "OnBought";
            public const string FinishLevel = "OnFinish";
            public const string TimeOver = "TimeOver";
        }

        public class BaseColors
        {
            public static List<Color> colors = new()
            {
                Color.red,
                Color.blue,
                Color.green,
                Color.yellow,
                Color.magenta,
                Color.green,
                Color.red
            };
        }
    }
}