using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField]
	private int health = 100;
    [SerializeField]
    private GameObject deathScreen;
    [SerializeField]
	private HealthBar healthBar;
	[SerializeField]
	private int takeDamage = 10;

	public void TakeDamage(int damage)
	{

		health -= damage;

		healthBar.SetHealth(health);
		if (health <= 0)
		{
			Die();
            if (!deathScreen.activeSelf)
            {
                deathScreen.SetActive(true);
                Time.timeScale = 0f;
            }
        }
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		
		if (collision.gameObject.CompareTag("Enemy"))
		{
	
			TakeDamage(takeDamage);
		}
	}
	private void Die()
	{
		Debug.Log("You died!");
		Destroy(this.gameObject);
	}
}
