using UnityEngine;
using UniRx;
using System;
using Random = UnityEngine.Random;

namespace Board
{
    public class BoardInstanceController : MonoBehaviour
    {
        [SerializeField, Header("生成する壁のprefab")]
        private GameObject board;

        [SerializeField, Header("生成する感覚")]
        private float interval = 3f;

        private CompositeDisposable disposables = new();

        void Start()
        {
        }

        /// <summary>
        /// Boardの生成
        /// </summary>
        void LocalInstantiate()
        {
            GameObject obj = Instantiate(board);
            obj.transform.parent = transform;

            float y = Random.Range(-5f, 5f);
            obj.transform.localPosition = new Vector3(0f, y, 0f);
        }

        public void StartGame()
        {
            Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(interval))
                .Subscribe(x => LocalInstantiate())
                .AddTo(disposables);
        }

        private void OnDestroy()
        {
            disposables.Dispose();
        }
    }
}