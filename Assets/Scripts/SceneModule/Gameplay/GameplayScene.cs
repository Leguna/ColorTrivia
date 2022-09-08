using Global.Base;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SceneModule.Gameplay
{
    public class GameplayScene : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private GameFlowController _gameFlowController;

        private void Start()
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(GoToLevelScene);
            _gameFlowController.SetCallback(GoToLevelScene, GoToPackScene);
        }

        public void GoToLevelScene()
        {
            SceneManager.LoadScene(Consts.SceneNames.Level);
        }

        public void GoToPackScene()
        {
            SceneManager.LoadScene(Consts.SceneNames.Pack);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}