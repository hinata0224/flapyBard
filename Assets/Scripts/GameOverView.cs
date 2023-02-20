using UnityEngine;

namespace GameOverUI
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField, Header("ゲームオーバーパネル")]
        private GameObject gameOVerPanel;

        /// <summary>
        /// GameOverパネルを表示
        /// </summary>
        public void GameOver()
        {
            gameOVerPanel.SetActive(true);
        }
    }
}