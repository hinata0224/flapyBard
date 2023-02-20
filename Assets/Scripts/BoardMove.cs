using UnityEngine;
using UniRx;

namespace Board
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BoardMove : MonoBehaviour
    {
        [SerializeField, Header("移動速度")]
        private float speed = 1f;
        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            rb.mass = 0;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            Observable.EveryFixedUpdate()
                .Subscribe(_ => rb.velocity = Vector2.left * speed)
                .AddTo(this);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("wall"))
            {
                Destroy(gameObject);
            }
        }
    }
}