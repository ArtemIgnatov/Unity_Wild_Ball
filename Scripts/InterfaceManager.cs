using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats; // Игрок с которого считываем статы

    [SerializeField] private Text scoreText; // Поле счета
    [SerializeField] private Text finalScoreText; // Поле итогового счета
    [SerializeField] private Text lifesText; // Поле жизней
    [SerializeField] private Text timeText; // Поле времени прохождения уровня

    private float timer; // Время прохождения уровня


    public void Update()
    {
        timer += Time.deltaTime;

        DisplayTime(timer);

        scoreText.text = playerStats.score.ToString();// Транслируем счет на паель
        finalScoreText.text = scoreText.text;
        lifesText.text = playerStats.lifes.ToString();
    }

    /// <summary>
    /// Таймер прохождения уровня
    /// </summary>
    /// <param name="timeToDisplay"></param>
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
