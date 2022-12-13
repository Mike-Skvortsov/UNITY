using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float Speed = 9f;
    public int damage = 1;
    public Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
        RB.velocity = transform.right * Speed;   
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy != null)
		{
            enemy.TakeDamage(damage);
		}
        Destroy(gameObject);
	}
}
