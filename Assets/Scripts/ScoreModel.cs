using UniRx;
using System;

namespace Score
{
    public interface IReadScoreModel
    {
        void AddScore(int _score);
        IObservable<int> GetScore();
    }
    public class ScoreModel : IReadScoreModel
    {
        private ReactiveProperty<int> score = new(0);

        /// <summary>
        /// スコアを足す
        /// </summary>
        /// <param name="_score">足したい数</param>
        public void AddScore(int _score)
        {
            score.Value += _score;
        }

        /// <summary>
        /// scoreを監視する
        /// </summary>
        /// <returns>スコアの変更</returns>
        public IObservable<int> GetScore()
        {
            return score;
        }
    }
}