using System;
using System.Collections.Generic;
using UnityEngine;

namespace Global.Base
{
    [Serializable]
    public class BoughtPack
    {
        public List<LevelPack> items = new();
    }
}