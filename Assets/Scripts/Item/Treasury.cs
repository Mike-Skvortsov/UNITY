using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasury : MonoBehaviour
{
    private bool _nearPlayer = false;
    public bool _isChestOpen = false;
    public Animator _animator;
    public string _chestAnimationKey;

    void Update()
    {
        if (_nearPlayer && Input.GetKeyDown(KeyCode.F) && !_isChestOpen)
        {
            _isChestOpen = true;
            _animator.SetBool(_chestAnimationKey, _isChestOpen);
            treasureSystem.treasure += 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        _nearPlayer = true;
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        _nearPlayer = false;
    }
}
