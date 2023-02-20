using UnityEngine;

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

        private Rigidbody2D rb;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Jump()
        {
            rb.velocity = Vector3.up * power;
        }
    }
}