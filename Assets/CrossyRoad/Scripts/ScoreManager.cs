using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Settings")]
    [SerializeField] private int score = 0;
    [SerializeField] private int pointsPerStep = 5;

    [Header("Player")]
    [SerializeField] private Transform playerTransform; // detectar la posicion del jugador

    [Header("UI")]
    [SerializeField] private TMP_Text scoreText; // mostrar score en la interfaz de usuario

    private float posicionAnteriorZ; // para evitar que se puedan ganar puntos yendo atras adelante atras adelante
    // solo vamos a sumar puntos si llego mas lejos de lo que habia llegado antes

    void Start()
    {
        posicionAnteriorZ = playerTransform.position.z; // obtener la posicion inicial del jugador

    }

    void Update()
    {
        if (playerTransform.position.z > posicionAnteriorZ) // si el jugador se mueve hacia adelante
        {
            posicionAnteriorZ = playerTransform.position.z; // actualizar la posicion anterior
            score += pointsPerStep; // sumar puntos
            Debug.Log("Score: " + score);
            scoreText.text = "Puntos: " + score;
        }
    }

}
