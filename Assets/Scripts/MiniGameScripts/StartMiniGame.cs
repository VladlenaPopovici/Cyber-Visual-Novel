using Naninovel;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGameScripts
{
    [CommandAlias("minigame")]
    public class StartMiniGame : Command
    {
        public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            await SceneManager.LoadSceneAsync("MiniGame").ToUniTask();

            var miniGameManager = Object.FindObjectOfType<CardsController>();
            await miniGameManager.OnGameComplete();

            await SceneManager.LoadSceneAsync("SampleScene").ToUniTask();
        }
    }
}