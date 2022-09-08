using System.Collections.Generic;
using Global.Base;
using SceneModule.Level;
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
            EventManager.StartListening(Consts.EventsName.UnlockPack, TrackUnlockPack);
            EventManager.StartListening(Consts.EventsName.FinishLevel, TrackFinishLevel);
        }

        private void OnDisable()
        {
            EventManager.StopListening(Consts.EventsName.UnlockPack, TrackUnlockPack);
            EventManager.StopListening(Consts.EventsName.FinishLevel, TrackFinishLevel);
        }

        private void TrackFinishLevel(Dictionary<string, object> obj)
        {
            SendDataAnalytics("On Finish Level", LevelDataModel.FromDict(obj));
        }

        private void TrackUnlockPack(Dictionary<string, object> obj)
        {
            SendDataAnalytics("On Unlock Pack", LevelPack.FromDict(obj));
        }

        private void SendDataAnalytics(string key, string data)
        {
            Debug.Log($"{key} sent to analytics: {data}");
        }
    }
}