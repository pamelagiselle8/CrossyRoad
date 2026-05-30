using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject carPrefab; // prefab del carro a instanciar
    [SerializeField] private float spawnTime = 1f; // intervalo de tiempo entre cada aparición de carro
    [SerializeField] private bool moveRight = true;
    //1.5-3
    [SerializeField] private float carSize = 1.5f;

    private void Start()
    {
        // para llamar a SpawnCar en bucle cada spawnTime tiempo
        InvokeRepeating("SpawnCar", spawnTime, spawnTime);
        // Primero: Nombre del método a llamar
        // Segundo: Tiempo de espera antes de la primera llamada
        // Tercero: Intervalo de tiempo entre cada llamada después de la primera
    }

    private void SpawnCar()
    {
        // Instantiate(carPrefab, transform.position, transform.rotation);
        GameObject car = Instantiate(carPrefab, transform.position, transform.rotation);
        carSize = Random.Range(1.5f, 3f);
        car.transform.localScale = new Vector3(carSize, car.transform.localScale.y, car.transform.localScale.z);
        CarMovement carMovement = car.GetComponent<CarMovement>();
        if (carMovement != null) {
            carMovement.moveRight = moveRight;
        }
    }
}
