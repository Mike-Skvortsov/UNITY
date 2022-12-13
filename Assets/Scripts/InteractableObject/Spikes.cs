using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
	[SerializeField] private int damage;
	[SerializeField] private float damageDelay;

	private DragonMover playerMover;
	private float lastDamageTime;
	private void OnTriggerEnter2D(Collider2D collider)
	{
		playerMover = collider.GetComponent<DragonMover>();
		if (playerMover != null)
		{
			playerMover.TakeDamage(damage);
			lastDamageTime = Time.time;
		}
	}

	private void Update()
	{
		if (Time.time - lastDamageTime > damageDelay && playerMover != null)
		{
			playerMover.TakeDamage(damage);
			lastDamageTime = Time.time;
		}
	}

	private void OnTriggerExit2D(Collider2D collider)
	{
		DragonMover _playerMover = collider.GetComponent<DragonMover>();
		if (_playerMover == playerMover)
		{
			playerMover = null;
		}
	}
}
