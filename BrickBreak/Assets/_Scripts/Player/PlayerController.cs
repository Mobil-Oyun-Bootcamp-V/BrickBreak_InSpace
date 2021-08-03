using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerData
{
    bool IsPlaying;
    int counter;

    ObjectPool _objectPool;
    PlayerInput _playerInput;
    WeaponRotater _weaponRotater;
    void Awake()
    {
        _objectPool = FindObjectOfType<ObjectPool>();
        _playerInput = new PlayerInput(this);
        _weaponRotater = new WeaponRotater();
    }
    void Update()
    {
        if (IsPlaying)
        {
            return;
        }
        switch (PlayerManager.playerState)
        {
            case PlayerManager.PlayerState.FireMOD:
                _weaponRotater.RotateWeapon(weapon,_playerInput.Active());
                break;

            case PlayerManager.PlayerState.PlayingMOD:
                StartCoroutine(WaitAndPush());
                IsPlaying = true;
                break;
        }
    }
    IEnumerator WaitAndPush() 
    {
        yield return new WaitForSeconds(0.1f);
        _weaponRotater.Shout(_objectPool.GetBullet(spawnPoint), weapon, bulletSpeed);
        counter++;
        if (counter != ballCount) 
        {
           StartCoroutine(WaitAndPush());
        }
        else
        {
            counter = 0;
        }
    }
    public IEnumerator SetXPosition(Vector2 receiveTargetPos)
    {
        float time = 0;
        Vector2 startPosition = transform.position;
        Vector2 targetPosition = new Vector2(receiveTargetPos.x, transform.position.y);
        while (time < horizontalSpeed)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / horizontalSpeed);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }

}
