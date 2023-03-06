using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] private StateMachine stateMachine; // Мееджер управления сценой
    [SerializeField] private ParticleSystem deathEffect; // Эффект смерти
    [SerializeField] private AudioSource deathSound; // Звук смерти
    [SerializeField] private Transform startPosition; // Стартовая точка

    private Rigidbody playerRigidbody; 
    public int score = 0; // Счет
    public int lifes = 3; // Жизни


    public void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {

        // Делаем проверку на смерть персонажа от тригеров
        if (other.CompareTag("DeathTrigger"))
        {
            Death(); 
        }

        // Делаем проверку достиг ли персонаж финиша
        if (other.CompareTag("Finish"))
        {
            stateMachine.FinishScreen(); // Запускаем сцену финиша
        }
    }

    /// <summary>
    /// Метод смерти
    /// </summary>
    public void Death()
    {
        if (lifes > 1)
        {
            deathSound.Play(); // Воспроизводим звук смерти

            deathEffect.Play(); // Эффект смерти

            playerRigidbody.position = startPosition.position; // Возвращаем игрока в начало уровня

            lifes--; // Отнимаем жизнь
        }
        else stateMachine.GameOverScene(); // Если жизни закончились запускаем сцену проигрыша

    }
}
