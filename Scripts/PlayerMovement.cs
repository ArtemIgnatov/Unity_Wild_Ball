using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {

        [SerializeField, Range(0, 20)] private float speed = 10.0f; // Скорость перемещения персонажа
        [SerializeField, Range(0, 20)] private float jumpForce = 3.0f; // Сила прыжка персонажа
        [SerializeField] private Transform groundChekerTransform; // Объект для проверки где находится персонаж
        [SerializeField] private LayerMask groundLayer; // Поле для определения слоя земли
        [SerializeField] private AudioSource jumpSound; // Звук прыжка
        private Rigidbody playerRigidbody; // Физическое тело персонажа


        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>(); // Задаем физическое тело персонажа
        }

        /// <summary>
        /// Метод перемещения персонажа
        /// </summary>
        /// <param name="movement"></param>
        public void MoveCharacter(Vector3 movement)
        {
            playerRigidbody.AddForce(movement * speed);

        }

        /// <summary>
        /// Метод для прыжка
        /// </summary>
        public void Jump(bool jumpTriger)
        {
            // Делаем проверку находится ли персонаж на земле, чтобы не допустить прыжков в воздухе
            if (jumpTriger == true && Physics.Raycast(groundChekerTransform.position, Vector3.down, 1.0f, groundLayer))
            {
                playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Прикладываем силу к персонажу

                jumpSound.Play(); // Воспроизводим звук прыжка
            }
            
        }
    }
}

