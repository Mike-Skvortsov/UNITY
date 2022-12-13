using UnityEngine;

public class lever : MonoBehaviour
{
	private bool leverActive = false;
	private bool go = false;
	[SerializeField] BoxCollider2D Collider2D;
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F) && leverActive && !go)
		{
			transform.Rotate(0, 0, -90);
			transform.position = new Vector3(102, 3.67f, -0.08f);
			go = !go;
			Collider2D.enabled = false;
		}	
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		leverActive = true;

	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		leverActive = false;
	}
}
