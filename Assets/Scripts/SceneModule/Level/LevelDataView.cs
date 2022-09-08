using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SceneModule.Level
{
    public class LevelDataView : MonoBehaviour
    {
        private LevelDataModel _levelDataModel;
        private Action<string> _onLevelSelect;
        [SerializeField] private TMP_Text _levelNameLabel;
        [SerializeField] private Transform _completeImage;
        [SerializeField] private Button _selectButton;


        public void SetData(LevelDataModel data)
        {
            _levelDataModel = data;
            _levelNameLabel.text = data.name;
            _completeImage.gameObject.SetActive(data.isCompleted);
        }

        public void SetCallback(Action<string> onLevelSelect)
        {
            _selectButton.onClick.RemoveAllListeners();
            _selectButton.onClick.AddListener(() => onLevelSelect(_levelDataModel.levelId));
        }
    }
}