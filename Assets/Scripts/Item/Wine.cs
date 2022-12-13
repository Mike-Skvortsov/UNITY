using UnityEngine;

public class Wine : MonoBehaviour
{
    private bool _nearPlayer = false;
    [SerializeField] private float _upgradeSpeed;
    public float UpgradeSpeed => _upgradeSpeed;
    void Update()
    {
        if (_nearPlayer)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        _nearPlayer = true;
	}
	private void OnTriggerExit2D(Collider2D collider)
    {
        _nearPlayer = false;
        collider.GetComponent<Shooter>().fire = true;
    }
}
