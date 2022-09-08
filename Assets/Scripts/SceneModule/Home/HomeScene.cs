using Global.Base;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SceneModule.Home
{
    public class HomeScene : MonoBehaviour
    {
        [SerializeField] private Button _playButton;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _playButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(StartPlay);
        }

        public void StartPlay()
        {
            SceneManager.LoadScene(Consts.SceneNames.Pack);
        }
    }
}