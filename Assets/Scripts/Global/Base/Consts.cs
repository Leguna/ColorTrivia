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
        }

        public static class EventsName
        {
            public const string UnlockPack = "OnBought";
            public const string FinishLevel = "OnFinish";
            public const string TimeOver = "TimeOver";
        }
    }
}