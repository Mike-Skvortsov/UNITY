using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phoenix : MonoBehaviour
{
    public float speed = 3;
    public Transform[] point;
    public int i = 1;

    [SerializeField] private Animator Animator;
    [SerializeField] private string RunAnimationKey;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, point[i].position, speed * Time.fixedDeltaTime);
        if(Vector2.Distance(transform.position, point[i].position) < 0.2f)
		{
            if(i > 0)
			{
                i = 0;
			}
            else
			{
                i = 1;
			}
		}
    }
}
