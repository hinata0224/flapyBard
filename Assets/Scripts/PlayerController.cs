using UnityEngine;
using Score;
using GameOverUI;

namespace Player
{
    public interface IReadPlayer
    {
        void Jump();
    }

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour, IReadPlayer
    {
        [SerializeField, Header("ジャンプ力")]
        private float power = 2f;

        private bool isPlaying = true;

        private Rigidbody2D rb;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Jump()
        {
            if (isPlaying)
            {
                rb.velocity = Vector3.up * power;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Score"))
            {
                if (isPlaying)
                {
                    ScoreViewPresenter.AddScore(1);
                }
            }
            else if (other.CompareTag("Board"))
            {
                isPlaying = false;
                rb.gravityScale = 0;
                rb.velocity = Vector3.zero;
                GameOverPresenter.GameOver();
            }
        }
    }
}