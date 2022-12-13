using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{
	[SerializeField] private int damage;
	private DragonMover playerMover;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		playerMover = collider.GetComponent<DragonMover>();
		if (playerMover != null)
		{
			playerMover.TakeDamage(-damage);
			Destroy(gameObject);
		}
	}
}
