using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	private bool _isAttacking;
	private Animator _animator;
    public ScoreScript scoreScript;

    private void Awake()
	{
		_animator = GetComponent<Animator>();

        scoreScript = FindObjectOfType<ScoreScript>();
        if (scoreScript == null)
        {
            Debug.LogError("ScoreScriptV2 not found in the scene. Make sure it is attached to a GameObject.");
        }
        else
        {
            scoreScript.customStart(); // Inicializa el texto de puntuación
        }
    }

	private void LateUpdate()
	{
		// Animator
		if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) {
			_isAttacking = true;
		} else {
			_isAttacking = false;
		}
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isAttacking)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.SendMessageUpwards("AddDamage");
                scoreScript.AddScore(10); // Añade 10 puntos por un enemigo normal
                Debug.Log("Hit an enemy. Added 10 points.");
            }
            else if (collision.CompareTag("Strong Enemy"))
            {
                collision.SendMessageUpwards("AddDamage");
                scoreScript.AddScore(20); // Añade 20 puntos por un enemigo grande
                Debug.Log("Hit a big bullet. Added 20 points.");
            }
        }
    }
}
