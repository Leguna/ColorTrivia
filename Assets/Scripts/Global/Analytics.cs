using System.Collections.Generic;
using Global.Base;
using UnityEngine;
using Utilities.Event;

namespace Global
{
    public class Analytics : MonoBehaviour
    {
        private void OnEnable()
        {
            Init();
        }

        private void Init()
        {
            EventManager.StartListening(Consts.EventsName.OnBought, OnPlayerBoughtPack);
            EventManager.StartListening(Consts.EventsName.OnFinish, OnPlayerFinishLevel);
        }


        private void OnDisable()
        {
            EventManager.StopListening(Consts.EventsName.OnBought, OnPlayerBoughtPack);
            EventManager.StopListening(Consts.EventsName.OnFinish, OnPlayerFinishLevel);
        }

        private void OnPlayerFinishLevel(Dictionary<string, object> obj)
        {
            SendDataAnalytics("OnFinish", obj.ToString());
        }

        private void OnPlayerBoughtPack(Dictionary<string, object> obj)
        {
            SendDataAnalytics("OnBought", obj.ToString());
        }

        private void SendDataAnalytics(string key, string data)
        {
            Debug.Log($"{key} sent to analytics: {data}");
        }
    }
}