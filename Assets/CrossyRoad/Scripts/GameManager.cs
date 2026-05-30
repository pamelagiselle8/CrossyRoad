using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Esta funcion es publica para poderla usar en el boton de reiniciar juego
    public void RestartGame() {
        losePanel.SetActive(false);
        Time.timeScale = 1f; // Reinicia el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia la escena actual
    }

    public void QuitGame() {
        Application.Quit(); // Cierra la aplicacion
    }

    [SerializeField] public GameObject losePanel;
    public static GameManager Instance { get; private set; }
    public void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void gameOver() {
        losePanel.SetActive(true);
        losePanel.transform.SetAsLastSibling();
    }
}
