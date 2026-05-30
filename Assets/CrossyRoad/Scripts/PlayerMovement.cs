using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    // Para que el jugador se mueva de forma fluida:
    // [SerializeField] private float speed = 5f;

    // void Update()
    // {
    //     float horizontalInput = Input.GetAxis("Horizontal"); // Obtener input horizontal (A/D o flechas)
    //     float verticalInput = Input.GetAxis("Vertical"); // Obtener input vertical (W/S o flechas)

    //     Vector3 direccion = new Vector3(horizontalInput, 0, verticalInput);
    //     transform.position += direccion * speed * Time.deltaTime;
    // }

    [SerializeField] private float stepSize = 1f;
    [SerializeField] private float rayDistance = 1f;

    private void Move(Vector3 direccion) {
        if (canMove(direccion)) {
            transform.position += direccion * stepSize;
        }
    }

    private bool canMove(Vector3 direction) {
        Ray ray = new Ray(transform.position, direction);
        if (Physics.Raycast(ray, rayDistance, ~0, QueryTriggerInteraction.Ignore)) {
            return false;
        }
        return true;
    }

    // Para moverse por steps como en crossy road:
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            Move(Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            Move(Vector3.back);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            Move(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            Move(Vector3.right);
        }
    }
}
