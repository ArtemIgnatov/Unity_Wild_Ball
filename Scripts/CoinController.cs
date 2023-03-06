using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private AudioSource coinSound;
    private Animator coinAnimator;

    public void Awake()
    {
        coinAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectCoin();
        }   
    }


    /// <summary>
    /// Метод подбора моетки
    /// </summary>
    /// <param name="coin"></param>
    private void CollectCoin()
    {
        coinAnimator.SetTrigger("Collect");
        coinSound.Play(); // Воспроизводим звук подбора монетки

        Destroy(this.gameObject, 0.2f); // Удаляем объект со сцены

        playerStats.score++; // Прибавляем счет
    }
}
