using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerData
{
    int counter;

    Pool _bulletPool;
    PlayerInput _playerInput;
    WeaponRotater _weaponRotater;
    void Awake()
    {
        _bulletPool = GameObject.FindGameObjectWithTag("BulletPool").GetComponent<Pool>();
        _playerInput = new PlayerInput(this);
        _weaponRotater = new WeaponRotater();
    }
    void Update()
    {
        switch (PlayerManager.playerState)
        {
            case PlayerManager.PlayerState.PlayingMOD:
                return;

            case PlayerManager.PlayerState.EndMOD:
                return;

            case PlayerManager.PlayerState.AimMOD:
                _weaponRotater.RotateWeapon(weapon,_playerInput.Active());
                break;

            case PlayerManager.PlayerState.FireMOD:
                StartCoroutine(WaitAndFire());
                PlayerManager.SetMOD("PlayingMOD");
                break;
        }
    }
    IEnumerator WaitAndFire() 
    {
        yield return new WaitForSeconds(0.05f);
        _weaponRotater.Shout(_bulletPool.GetObject(spawnPoint), weapon, bulletSpeed);
        counter++;
        if (counter != ballCount) 
        {
           StartCoroutine(WaitAndFire());
        }
        else
        {
            counter = 0;
        }
    }
    public void Move(Vector2 receiveTargetPos)
    {
       StartCoroutine(SupportClass.LerpMove(this.gameObject, transform.position, new Vector2(receiveTargetPos.x, transform.position.y), 1));
    }

}
