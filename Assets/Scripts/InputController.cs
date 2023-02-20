using UnityEngine;
using UniRx;
using System;

namespace PlayerInput
{
    public class InputController : MonoBehaviour
    {
        private Subject<Unit> jump = new();

        void Start()
        {
            Observable.EveryUpdate()
                .Where(_ => Input.GetMouseButtonDown(0))
                .Subscribe(_ => jump.OnNext(Unit.Default))
                .AddTo(this);
        }

        public IObservable<Unit> GetJump()
        {
            return jump;
        }
    }
}