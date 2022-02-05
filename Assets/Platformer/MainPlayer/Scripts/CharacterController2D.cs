using UnityEngine;

namespace Player.Scripts
{
    public class CharacterController2D : MonoBehaviour
    {
        public float speed = 14f;
        public float accel = 6f;
        private Vector2 _input;
        private Rigidbody2D _rb;
        private SpriteRenderer[] _spriteRenderers;
    
        void Awake() 
        {
            _rb = GetComponent<Rigidbody2D>();
            _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        }

        void Update()
        {
            _input.x = Input.GetAxis("Horizontal");
            _input.y = Input.GetAxis("Jump");
            
            foreach (var sr in _spriteRenderers)
            {
                if (_input.x > 0f)
                    sr.flipX = false;
                else if (_input.x < 0f) sr.flipX = true;
            }
        }
        
        void FixedUpdate() 
        {
            var acceleration = accel;
            var xVelocity = _input.x == 0 ? 0f : _rb.velocity.x;

            _rb.AddForce(new Vector2(((_input.x * speed) - _rb.velocity.x) * acceleration, 0));
            _rb.velocity = new Vector2(xVelocity, _rb.velocity.y);
        }
    }
}
