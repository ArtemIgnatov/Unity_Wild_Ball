using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]
    
    public class PlayerController : MonoBehaviour
    {

        private PlayerMovement playerMovement; // Экземпляр класса определяющий перемещение персонажа
        private Vector3 inputMovement; // Вектор введеных значений с клавиш управления
        [SerializeField] private Transform firstCamera; // Камера относительно которой будет расчитываться вектор перемещения
        [SerializeField] private float smoothTime; // Время для плавного поворота персонажа

        private float smoothVelocity; // Скорость с которой персонаж поворачивается относительно камеры
        private Animator playerAnim; // Аниматор персонажа
        private bool isPlayerJump; // Тригер прыжка

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            playerAnim = GetComponent<Animator>(); // Задаем аниматор персонажа
        }


        void Update()
        {

            float horizontal = Input.GetAxis(GlobasStringVars.horizontalAxis); // Горизонтальное введенное значение
            float vertical = Input.GetAxis(GlobasStringVars.verticalAxis); // Вертикальное введенное значение
            inputMovement = new Vector3(horizontal, 0, vertical).normalized; // Нормальный вектор введенных значений

            // Проверяем производится ли ввод с клавиатуры, для того чтобы запустить анимацию движения или покоя
            if (inputMovement.magnitude != 0)
            {
                //Передаем в аниматор персонажа значение для проигрования нужной анимации
                playerAnim.SetBool("InputAction", true);
            }
            else playerAnim.SetBool("InputAction", false);

            // Прыжок
            playerMovement.Jump(Input.GetKeyDown(KeyCode.Space));



        }

        private void FixedUpdate()
        {

            // Проверяем на ввод с клавиш управления
            if (inputMovement.magnitude >= 0.1f)
            {

                // Определяем вектор введенного значения относительно угла обзора камеры
                float rotationAngle = Mathf.Atan2(inputMovement.x, inputMovement.z) * Mathf.Rad2Deg + firstCamera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationAngle, ref smoothVelocity, smoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                // Получаем необходимый вектор для перемещени персонажа в пространстве
                Vector3 move = Quaternion.Euler(0f, rotationAngle, 0f) * Vector3.forward;

                // Вызываем метод перемещения
                playerMovement.MoveCharacter(move);

            }

        }
    }
}

