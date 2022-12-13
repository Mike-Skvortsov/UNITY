using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpeed : MonoBehaviour
{
	[SerializeField] private float _upgradeTime;
	[SerializeField] private float _upgradeSpeed;
	public float UpgradeTime => _upgradeTime;
	public float UpgradeSpeed => _upgradeSpeed;
}
