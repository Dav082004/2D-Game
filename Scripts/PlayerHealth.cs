using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public int totalHealth = 3;
    public RectTransform heartUI;

    //Game Over
    public RectTransform gameOverMenu;
    public GameObject hordes;

	private int health;
    private float heartSize = 16f;

	private SpriteRenderer _renderer;
    private Animator _animator;
    private PlayerController _controller;


	private void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _controller = GetComponent<PlayerController>();
	}

	void Start()
    {
		health = totalHealth;   
    }

	public void AddDamage(int amount)
	{
		health = health - amount;

		// Visual Feedback
		StartCoroutine("VisualFeedback");

		// Game  Over
		if (health <= 0) {
			health = 0;
            gameObject.SetActive(false);
		}

        heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);
		Debug.Log("Player got damaged. His current health is " + health);
	}

	public void AddHealth(int amount)
	{
		health = health + amount;
            
        // Visual Feedback
        StartCoroutine("VisualFeedback");

        // Max health
        if (health > totalHealth) {
			health = totalHealth;
		}

        heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);
        Debug.Log("Player got some life. His current health is " + health);
	}

	private IEnumerator VisualFeedback()
	{
		_renderer.color = Color.red;

		yield return new WaitForSeconds(0.1f);

		_renderer.color = Color.white;
	}

    private void OnEnable()
    {
        health = totalHealth;
    }

    private void OnDisable()
    {
        gameOverMenu.gameObject.SetActive(true);

        _animator.enabled = false;
        _controller.enabled = false;
    }
}
