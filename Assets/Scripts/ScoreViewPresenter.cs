using UniRx;

namespace Score
{
    public class ScoreViewPresenter
    {
        private static IReadScoreModel score;
        private ScoreView view;

        private CompositeDisposable disposables = new();
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="_scoreModel">ScoreModel</param>
        /// <param name="_view">ScoreView</param>
        public ScoreViewPresenter(IReadScoreModel _scoreModel, ScoreView _view)
        {
            score = _scoreModel;
            view = _view;

            score.GetScore()
                .Subscribe(x => view.SetScoreText(x))
                .AddTo(disposables);
        }
        /// <summary>
        /// スコアを足す
        /// </summary>
        /// <param name="_score">足す数</param>
        public static void AddScore(int _score)
        {
            score.AddScore(_score);
        }

        public void CallGameEnd()
        {
            disposables.Dispose();
        }
    }
}