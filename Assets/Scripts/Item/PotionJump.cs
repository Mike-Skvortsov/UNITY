using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionJump : MonoBehaviour
{
	[SerializeField] private float _upgradeTime;
	[SerializeField] private float _upgradePower;
	public float UpgradeTime => _upgradeTime;
	public float UpgradePower  => _upgradePower;
}
