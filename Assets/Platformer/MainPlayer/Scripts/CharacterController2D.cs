using UnityEngine;

namespace Player.Scripts
{
    public class CharacterController2D : MonoBehaviour
    {
        //Скорость
        public float speed = 14f;
        //Ускорение
        public float accel = 6f;
        //Вектор полученного направления 
        private Vector2 _input;
        private Rigidbody2D _rb;
        private SpriteRenderer[] _spriteRenderers;
    
        //Вызывается Unity как только Unity создала наш объект, но еще не разместила в графическом мире
        void Awake() 
        {
            _rb = GetComponent<Rigidbody2D>();
            _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        }

        void Update()
        {
            //Читаем в наш вектор запись по горизонтали
            _input.x = Input.GetAxis("Horizontal");
            
            //Что делает данный код ? 
            foreach (var sr in _spriteRenderers)
            {
                if (_input.x > 0f)
                    sr.flipX = false;
                else if (_input.x < 0f) sr.flipX = true;
            }
        }
        
        void FixedUpdate() 
        {
            //"Толкаем" нашего персонажа, рассчитываем силу толчка 
            _rb.AddForce(new Vector2((_input.x * speed - _rb.velocity.x) * accel, 0));
        }
    }
}
