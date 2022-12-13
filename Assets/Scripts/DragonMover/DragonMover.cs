using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DragonMover : MonoBehaviour
{
	[Header("Stats")]
	[SerializeField] private int MaxHP;
	[SerializeField] private Slider slider;
	private bool die = false;
	[SerializeField] private TMP_Text HPText;

	private int CurrentHP;

	[Header("Movement")]
	[SerializeField] private float GroundCheckerRadius;
	[SerializeField] private Rigidbody2D Rigidbody;
	[SerializeField] private Transform Transform;
	[SerializeField] private float Speed;
	[SerializeField] private float JumpPower;
	[SerializeField] private Transform GroundChecker;
	[SerializeField] private LayerMask WhatIsGround;
	[SerializeField] private int JumpCount;
	[SerializeField] private int JumpCountMax;
	[SerializeField] private Transform CellChecker;
	[SerializeField] private float CellCheckerRadius;
	[SerializeField] private float crouchSpeed;
	[SerializeField] private Collider2D HeadCollider;
	[SerializeField] private float StartSpeed;

	[Header("Animation")]
	[SerializeField] private Animator Animator;
	[SerializeField] private string RunAnimationKey;
	[SerializeField] private string DieAnimationKey;
	[SerializeField] private string CrouchAnimationKey;
	[SerializeField] private string FlyAnimationKey;
	[SerializeField] private string FallAnimationKey;
	[SerializeField] private string wineAnimationKey;
	[SerializeField] private float time;

	private bool wine = false;
	private bool SpeedWithPotion = false;
	private float startCountJump = 3;
	private bool faceRight = true;
	// Start is called before the first frame update
	void Start()
	{
		SpeedWithPotion = false;
		CurrentHP = MaxHP;
		StartSpeed = Speed;
		startCountJump = JumpCountMax;
		slider.maxValue = MaxHP;
		slider.value = CurrentHP;
		HPText.text = CurrentHP.ToString();
		wine = false;
	}

	public void TakeDamage(int damage)
	{
		CurrentHP -= damage;
		if (CurrentHP > 100)
		{
			CurrentHP = 100;
		}
		else if (CurrentHP < 0)
		{
			CurrentHP = 0;
		}
		slider.value = CurrentHP;
		HPText.text = CurrentHP.ToString();
		if (CurrentHP <= 0)
		{
			die = true;
			StartSpeed = 0;
			Animator.SetBool(DieAnimationKey, die);
			Invoke(nameof(Die), time);
		}
	}
	public void Die()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	private void Destroy()
	{
		Destroy(gameObject);
	}

	// Update is called once per frame
	private void Update()
	{
		var grounded = Physics2D.OverlapCircle(GroundChecker.position, GroundCheckerRadius, WhatIsGround);
		Vector2 velocity = Rigidbody.velocity;
		var direction = Input.GetAxis("Horizontal");


		Animator.SetBool(RunAnimationKey, direction != 0 && grounded && !die);
		Animator.SetBool(FallAnimationKey, !grounded);

		Animator.SetBool(wineAnimationKey, wine);

		if (grounded)
		{
			Rigidbody.velocity = new Vector2(Speed * direction, velocity.y);
			JumpCount = 1;
		}
		if (direction < 0 && faceRight || direction > 0 && !faceRight)
		{
			Flip();
		}
		if (Input.GetButtonDown("Jump") && JumpCount < JumpCountMax && !die)
		{
			JumpCount++;
			Rigidbody.velocity = new Vector2(velocity.x, JumpPower);
			Animator.SetBool(FlyAnimationKey, true);
		}
		else
		{
			Animator.SetBool(FlyAnimationKey, false);
		}

		bool cellMove = Physics2D.OverlapCircle(CellChecker.position, CellCheckerRadius, WhatIsGround);
		Animator.SetBool(CrouchAnimationKey, !HeadCollider.enabled);
		if (Input.GetKey(KeyCode.LeftControl) && !die)
		{
			HeadCollider.enabled = false;
			Speed = StartSpeed;
			if (!SpeedWithPotion)
			{
				Speed = crouchSpeed;
			}
		}

		else if (!cellMove)
		{
			HeadCollider.enabled = true;
			if (!SpeedWithPotion && !wine)
			{
				ResetSpeed();
			}
		}
	}
	private void Flip()
	{
		Invoke(nameof(ResetWine), 1.8f);
		faceRight = !faceRight;
		Transform.Rotate(0, 180, 0);
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		PotionJump potionJump = collider.GetComponent<PotionJump>();
		PotionSpeed potionSpeed = collider.GetComponent<PotionSpeed>();
		Wine Wine = collider.GetComponent<Wine>();
		if (potionSpeed != null)
		{
			SpeedWithPotion = true;
			Speed = potionSpeed.UpgradeSpeed;
			Invoke(nameof(ResetSpeed), potionSpeed.UpgradeTime);
		}
		if (potionJump != null)
		{
			JumpCountMax = (int)potionJump.UpgradePower;
			Invoke(nameof(ResetJump), potionJump.UpgradeTime);
		}
		if (Wine != null)
		{
			Speed = Wine.UpgradeSpeed;
			wine = true;
			Animator.SetBool(wineAnimationKey, wine);
		}
	}
	private void ResetWine()
	{
		wine = false;
	}

	private void ResetJump()
	{
		JumpCountMax = (int)startCountJump;
	}

	private void ResetSpeed()
	{
		Speed = StartSpeed;
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(GroundChecker.position, GroundCheckerRadius);
		Gizmos.color = Color.black;
		Gizmos.DrawWireSphere(CellChecker.position, CellCheckerRadius);
	}
}
