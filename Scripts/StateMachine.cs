using UnityEngine;
using UnityEngine.SceneManagement;

public class StateMachine : MonoBehaviour
{

    [SerializeField] private GameObject finishScreen; // Сцена финиша
    [SerializeField] private GameObject _interface; // Интерфейс
    [SerializeField] private GameObject gameOverScreen; // Сцена проигрыша


    /// <summary>
    /// Загрузить уровень
    /// </summary>
    /// <param name="sceneNum"></param>
    public void LoadLevel(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
        Time.timeScale = 1;
    }

    /// <summary>
    /// Начать уровень заново
    /// </summary>
    public void RestartTheLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

    }

    /// <summary>
    /// Кнопка паузы
    /// </summary>
    public void PauseButton()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// Кнопка вернуться в игру
    /// </summary>
    public void ResumeButton()
    {
        Time.timeScale = 1;
    }

    /// <summary>
    /// Кнопка следующего уровня
    /// </summary>
    public void ContinueButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }


    /// <summary>
    /// Загрузка сцены смерти
    /// </summary>
    public void GameOverScene()
    {
        Time.timeScale = 0; // Останавливаем время
        gameOverScreen.SetActive(true); // Открываем сцену проигрыша
    }

    /// <summary>
    /// Загрузка сцены финиша
    /// </summary>
    public void FinishScreen()
    {
        Time.timeScale = 0; // Останавливаем время
        _interface.SetActive(false); // Скрываем интерфейс
        finishScreen.SetActive(true); // Открываем канвас финиша
    }
}
