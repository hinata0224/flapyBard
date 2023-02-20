using UnityEngine;
using TMPro;

namespace Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField, Header("スコアテキスト")]
        private TextMeshProUGUI scoreText;

        public void SetScoreText(int _score)
        {
            scoreText.text = "Score : " + _score;
        }
    }
}