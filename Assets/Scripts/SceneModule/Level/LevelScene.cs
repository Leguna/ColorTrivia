using Global;
using Global.Base;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SceneModule.Level
{
    public class LevelScene : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private LevelDataController _levelDataController;

        private void Start()
        {
            _levelDataController.SetCallback(LevelSelect);
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(GoBack);
        }

        private void LevelSelect(string levelID)
        {
            SaveData.Instance.SetLevelDataSelectedId(levelID);
            SceneManager.LoadScene(Consts.SceneNames.Gameplay);
        }

        private void GoBack()
        {
            SceneManager.LoadScene(Consts.SceneNames.Pack);
        }
    }
}