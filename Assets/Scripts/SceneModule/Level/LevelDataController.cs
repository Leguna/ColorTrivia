using System;
using System.Collections.Generic;
using Global;
using Global.Base;
using TMPro;
using UnityEngine;

namespace SceneModule.Level
{
    public class LevelDataController : MonoBehaviour
    {
        [SerializeField] private Transform _groupTransform;
        [SerializeField] private TMP_Text _levelText;
        private Action<string> _onLevelAction;
        private List<LevelDataModel> _listLevelDataModel;

        public void SetCallback(Action<string> onLevelSelect)
        {
            _onLevelAction = onLevelSelect;
        }

        private void Start()
        {
            LoadLevelList();
            InitLevelList(_listLevelDataModel.ToArray());
        }

        private void LoadLevelList()
        {
            var currentPackId = SaveData.Instance.PackSelectedId ?? "A";
            var levelPack = SaveData.Instance.database.GetLevelPackById(currentPackId);
            _levelText.text = levelPack.packName;
            var pathListLevelData = Consts.Resources.LevelData + currentPackId + "/";
            _listLevelDataModel = new List<LevelDataModel>(Resources.LoadAll<LevelDataModel>(pathListLevelData));
        }

        public void InitLevelList(LevelDataModel[] levelData)
        {
            foreach (var data in levelData)
            {
                var levelDataView = Instantiate(Resources.Load<LevelDataView>(Consts.Resources.LevelDataView),
                    _groupTransform);
                data.isCompleted = SaveData.Instance.IsLevelCompleted(data.levelId);
                levelDataView.SetData(data);
                levelDataView.SetCallback(OnLevelSelect);
                _listLevelDataModel.Add(data);
            }
        }

        public LevelDataModel[] GetLevelList()
        {
            return _listLevelDataModel.ToArray();
        }

        private void OnLevelSelect(string obj)
        {
            _onLevelAction?.Invoke(obj);
        }
    }
}