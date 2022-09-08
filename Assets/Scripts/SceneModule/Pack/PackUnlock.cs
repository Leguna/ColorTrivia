using System.Collections.Generic;
using Global;
using Global.Base;
using Utilities.Event;

namespace SceneModule.Pack
{
    public class PackUnlock
    {
        public bool TryBuyPack(LevelPack levelPack)
        {
            var isSuccess = Currency.Instance.TryBuy(levelPack);
            if (isSuccess)
            {
                EventManager.TriggerEvent(Consts.EventsName.UnlockPack,levelPack.ToDict());
            }

            return isSuccess;
        }
    }
}