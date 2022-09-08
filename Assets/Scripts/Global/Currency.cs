using System;
using System.Collections.Generic;
using Global.Base;
using UnityEngine;
using Utilities;
using Utilities.Event;

namespace Global
{
    [Serializable]
    public class Currency : SingletonMonoBehaviour<Currency>
    {
        public SaveData saveData;

        protected void Start()
        {
            saveData = SaveData.Instance;
        }

        public int AddGold(int amount)
        {
            saveData.gold += amount;
            saveData.Save();
            return saveData.gold;
        }

        public int SpendCoin(int amount)
        {
            saveData.gold -= amount;
            saveData.Save();
            return saveData.gold;
        }

        public bool TryBuy(LevelPack levelPack)
        {
            if (saveData.boughtPack.items.Contains(levelPack.packId))
            {
                Debug.Log("Already Bought");
                return false;
            }

            var price = saveData.database.levelPacks.Find(pack => pack.packId == levelPack.packId).price;
            if (saveData.gold < price)
            {
                Debug.Log("Not Enough Money");
                return false;
            }

            EventManager.TriggerEvent(Consts.EventsName.OnBought, levelPack.ToJson());
            SpendCoin(price);
            saveData.boughtPack.items.Add(levelPack.packId);
            saveData.Save();
            return true;
        }
    }
}