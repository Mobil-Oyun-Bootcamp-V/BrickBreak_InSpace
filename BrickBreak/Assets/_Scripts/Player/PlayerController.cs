using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject weapon;

    PlayerInput _playerInput;
    WeaponRotater _weaponRotater;
    void Awake()
    {
        _playerInput = new PlayerInput(this);
        _weaponRotater = new WeaponRotater(weapon);
    }
    void Update()
    {
        if (PlayerManager.playerState == PlayerManager.PlayerState.FireMOD)
        {
            _weaponRotater.RotateWeapon(_playerInput.Active());
        }
        Debug.Log(PlayerManager.playerState);
    }
}
