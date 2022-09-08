using System;
using System.Collections.Generic;
using Global.Base;

namespace Global
{
    [Serializable]
    public class CompletedLevel
    {
        public List<LevelData> items = new();
    }
}