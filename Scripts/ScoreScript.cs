using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int scoreValue = 0;
    public GameObject winMenu;
    public GameObject horde;

    private SpriteRenderer _renderer;
    private Animator _animator;
    private PlayerController _controller;

    void Start()
    {
        customStart(); // Inicializa el texto de puntuación
    }


    void Update()
    {
        scoreText.text = "Score: " + scoreValue;
        CheckGameOver(); // Verifica si el juego debe terminar
    }

    public void AddScore(int points)
    {
        scoreValue += points;
        Debug.Log("Score added: " + points + ". New score: " + scoreValue);
        customUpdate(); // Actualiza la visualización del puntaje
    }

    private void CheckGameOver()
    {
        if (scoreValue >= 50)
        {
            
            Debug.Log("YOU WIN!!!!");
            winMenu.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void customStart()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }


    public void customUpdate()
    {
        scoreText.text = "Score: " + scoreValue;
    }

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _controller = GetComponent<PlayerController>();
    }
    private void OnDisable()
    {
        winMenu.gameObject.SetActive(true);

        horde.SetActive(false);
        _animator.enabled = false;
        _controller.enabled = false;
    }
}
