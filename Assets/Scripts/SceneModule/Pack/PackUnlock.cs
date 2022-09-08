using Global;
using Global.Base;

namespace SceneModule.Pack
{
    public class PackUnlock
    {
        public bool TryBuyPack(LevelPack levelPack)
        {
            return Currency.Instance.TryBuy(levelPack);
        }
    }
}