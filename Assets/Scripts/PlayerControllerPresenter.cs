using UniRx;
using PlayerInput;

namespace Player
{
    public class PlayerControllerPresenter
    {
        private IReadPlayer controller;
        //interfaceを実装していなければ
        //private PlayerController controller;
        private InputController input;

        private CompositeDisposable disposables = new();

        // IReadPlayerを実装していない場合はPlayerController
        public PlayerControllerPresenter(IReadPlayer _player, InputController _input)
        {
            controller = _player;
            input = _input;

            input.GetJump()
                .Subscribe(_ => controller.Jump())
                .AddTo(disposables);
        }

        public void CallGameEnd()
        {
            disposables.Dispose();
        }
    }
}