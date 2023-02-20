using UniRx;
using PlayerInput;
using StartGame;
using Board;

namespace Player
{
    public class PlayerControllerPresenter
    {
        private IReadPlayer controller;
        //interfaceを実装していなければ
        //private PlayerController controller;
        private InputController input;

        private StartGameView gameView;

        private BoardInstanceController instanceController;

        private CompositeDisposable disposables = new();

        // IReadPlayerを実装していない場合はPlayerController
        public PlayerControllerPresenter(IReadPlayer _player, InputController _input, StartGameView _gameview,BoardInstanceController _instanceController)
        {
            controller = _player;
            input = _input;
            gameView = _gameview;
            instanceController = _instanceController;

            input.GetJump()
                .Where(_ => gameView.GetStart())
                .Subscribe(_ => controller.Jump())
                .AddTo(disposables);

            input.GetJump()
                .Where(_ => !gameView.GetStart())
                .Subscribe(_ => 
                {
                    gameView.StartGame();
                    controller.GameStart();
                    instanceController.StartGame();
                })
                .AddTo(disposables);
        }

        public void CallGameEnd()
        {
            disposables.Dispose();
        }
    }
}