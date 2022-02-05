using UnityEngine;

namespace Platformer.DynamicBackground.Scripts
{
    public class Parallax : MonoBehaviour
    {
        //Длина нашего фона (одного страйта)
        private float _lenght;
        //Текущая стартовая позиция
        private float _startPosition;
    
        //Помечаем наше поле специальным атрибутом, который будет использовать редактор, для ограничения выставляемых значений
        [Range(0, 1)]
        //Скорость следования за камерой (0 точно за камерой)
        public float parallaxEffect;
        //Наша камера
        public GameObject mainCamera;

        void Start()
        {
            _startPosition = transform.position.x;
            //используем GetComponent для получения с GameObject SpriteRenderer и взятия его рамера по x
            _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        }
        
        //Функция вызываемая Unity, не зависящая от частоты кадров.
        void FixedUpdate()
        {
            //рассчитываем новую позицию для наших Sprite исходя из позиции нашей камеры
            var dist = mainCamera.transform.position.x * parallaxEffect;
            //Меняtv нашу позицию Sprite
            transform.position = new Vector3(
                _startPosition + dist, 
                transform.position.y, 
                transform.position.z);
            
            //Здесь мы создаем бесконечный фон
            //Рассчиваем позицию камеры с учетом параллах эффекта
            var temp = mainCamera.transform.position.x * (1 - parallaxEffect);
            //Если камера прошла два наших Sprite длину, двигаем позицию вправо
            if (temp > _startPosition + _lenght)
                _startPosition += _lenght;
            //иначе влево
            else if (temp < _startPosition) _startPosition -= _lenght;
        }
    }
}
