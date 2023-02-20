namespace GameOverUI
{
    public class GameOverPresenter
    {
        private static GameOverView view;

        public GameOverPresenter(GameOverView _view)
        {
            view = _view;
        }

        public static void GameOver()
        {
            view.GameOver();
        }
    }
}