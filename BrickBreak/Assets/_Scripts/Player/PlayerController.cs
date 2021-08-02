using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject weapon;
    [SerializeField] float bulletSpeed;
    [field:SerializeField] public int ballCount { get; set; }

    bool IsPlaying;
    int counter;
    ObjectPool _objectPool;
    PlayerInput _playerInput;
    WeaponRotater _weaponRotater;
    void Awake()
    {
        _objectPool = FindObjectOfType<ObjectPool>();
        _playerInput = new PlayerInput(this);
        _weaponRotater = new WeaponRotater(weapon);
    }
    void Update()
    {
        if (IsPlaying)
        {
            return;
        }
        if (PlayerManager.playerState == PlayerManager.PlayerState.FireMOD)
        {
            _weaponRotater.RotateWeapon(_playerInput.Active());
        }
        if (PlayerManager.playerState == PlayerManager.PlayerState.PlayingMOD)
        {   
            StartCoroutine(WaitAndPush());
            IsPlaying = true;
        }
    }
    IEnumerator WaitAndPush() 
    {
        yield return new WaitForSeconds(0.1f);
        _weaponRotater.Shout(_objectPool.GetBullet(spawnPoint), bulletSpeed);
        counter++;
        if (counter !=ballCount) 
        {
           StartCoroutine(WaitAndPush());
        }
        else
        {
            counter = 0;
        }
       
    }


}
