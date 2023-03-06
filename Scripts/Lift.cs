using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Lift : MonoBehaviour
{
    [SerializeField] GameObject pressEButtonPanel;

    [SerializeField] private Transform pointA; // точка A
    [SerializeField] private Transform pointB; // точка B
    private Vector3 platformPosition; // Текущая позиция платформы
    private Rigidbody platformRigidbody; 
    private float speed = 1.5f; // Скорость движения платформы
    private Transform target; // Точка к которой будет двигаться платформа
    private bool moveForward; // Тригер движения платформы
    private bool playerOnPlatform; // Тригер нахождения игрока на платформе

    private void Awake()
    {
        platformRigidbody = GetComponent<Rigidbody>();
        platformRigidbody.isKinematic = true; 
        moveForward = false; 
        playerOnPlatform = false; 
    }

    private void Update()
    {
        // Проверяем нажал ли игрок на кнопку и наодится ли он на платформе
        if (Input.GetKeyDown(KeyCode.E) && playerOnPlatform)
        {
            moveForward = true; // Запускаем платформу
            pressEButtonPanel.SetActive(false); // Закрываем окно подсказки
        }
    }

    private void FixedUpdate()
    {
        MovePlatform(moveForward); // Двигаем патформу
    }

    private void OnTriggerEnter(Collider other)
    {
        // Делаем проверку, если это игрок, то запускаем окно с подсказской
        if (other.CompareTag("Player"))
        {
            // Активируем окно подсказки
            pressEButtonPanel.SetActive(true);
        }     
    }


    private void OnTriggerStay(Collider other)
    {
        // Делаем проверку, находится ли игрок на платформе
        if (other.CompareTag("Player"))
        {
            // проверяем находится ли игрок на платформе, чтобы платформа не перемещалась без игрока
            playerOnPlatform = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Делаем проверку, если это игрок, то выключаем окно подсказки, если игрок покинул пдатформу
        if (other.CompareTag("Player"))
        {
            pressEButtonPanel.SetActive(false);
            playerOnPlatform = false;
        }
    }


    /// <summary>
    /// Метод движения платформы
    /// </summary>
    /// <param name="flag"></param>
    private void MovePlatform(bool flag)
    {
        if (flag == true)
        {
            // Определяем где находится платформа и в каком направление будет осуществлять движение
            if (platformRigidbody.position == pointB.position) target = pointA;
            if (platformRigidbody.position == pointA.position) target = pointB;

            // Определяем вектор направленя движения платформы
            platformPosition = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);

            // Передвигаем платформк
            platformRigidbody.MovePosition(platformPosition);

            // Проверяем достигла ли платформа своей цели и выключаем движение через moveForward
            if (platformPosition == target.position)
            {
                moveForward = false;
            }
        }
    }
}
