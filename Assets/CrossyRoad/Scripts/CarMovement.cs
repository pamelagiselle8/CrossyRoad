using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public bool moveRight = true;
    [SerializeField] private float speed = 5f; // velocidad del carro
    [SerializeField] private int xMax = 15; // distancia a la que el carro se destruirá

    void Update() {
        if (moveRight) {
            transform.position += Vector3.right * speed * Time.deltaTime; // mueve el carro hacia la derecha
            if (transform.position.x > xMax)
                Destroy(gameObject);
        } else {
            transform.position -= Vector3.right * speed * Time.deltaTime; // mueve el carro hacia la izquierda
            if (transform.position.x < -xMax)
                Destroy(gameObject);
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            Debug.Log("Game Over!");
            Time.timeScale = 0f;
            GameManager.Instance.gameOver();
        }
    }
}
