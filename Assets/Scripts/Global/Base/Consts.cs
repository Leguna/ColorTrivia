namespace Global.Base
{
    internal static class Consts
    {
        public static class SceneNames
        {
            public const string Home = "Home";
            public const string SelectPack = "SelectPack";
            public const string SelectLevel = "SelectLevel";
            public const string GameScene = "Gameplay";
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
            public const string LevelPackItemPrefab = "Prefabs/LevelPackItem";
        }

        public static class EventsName
        {
            public const string OnBought = "OnBought";
            public const string OnFinish = "OnFinish";
            public const string TimeOver = "TimeOver";
        }
    }
}