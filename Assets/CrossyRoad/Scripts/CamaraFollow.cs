using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // Este el objeto que la camara va a seguir (en este caso el jugador)
    [SerializeField] private Vector3 offset = new Vector3(0, 8, -10); // Distancia entre la camara y el jugador

    void LateUpdate() // Este se ejecuta despues del update
    {
        if (target == null)
        {
            Debug.LogError("Target is null");
            return;
        }

        // Nueva posicion de la camara
        transform.position = target.position + offset;
    }
}
