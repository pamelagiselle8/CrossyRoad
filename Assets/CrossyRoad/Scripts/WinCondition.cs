using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("¡Has ganado!");
            Time.timeScale = 0f; // Detiene el tiempo

            winPanel.SetActive(true);
        }
    }
}
