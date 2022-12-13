using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	public Transform FirePoint;
	public GameObject Fireball;
	public bool fire = false;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1") && fire)
		{
			var projectile = Instantiate(
				Fireball,
				FirePoint.position,
				FirePoint.rotation);
		}
	}
}
