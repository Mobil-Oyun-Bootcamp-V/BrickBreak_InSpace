using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomLine : MonoBehaviour
{
    Pool _bulletPool;
    PlayerController _playerController;
    
    bool firstEnemyControl;
    GameObject bullet;
    int activeBulletCount;
    void Awake()
    {
        _bulletPool = GameObject.FindGameObjectWithTag("BulletPool").GetComponent<Pool>();
        _playerController = FindObjectOfType<PlayerController>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        bullet = collision.gameObject;
      
        if (!firstEnemyControl)
        {
            if (bullet)
            {
                firstEnemyControl = true;
                _playerController.Move(bullet.transform.position);
            }
        }
        activeBulletCount++;
        
        _bulletPool.SetObject(bullet);
        BulletControl();
        
    }
    void BulletControl()
    {
        if (activeBulletCount == _playerController.ballCount)
        {
            activeBulletCount = 0;
            PlayerManager.SetMOD("AimMOD");
            firstEnemyControl = false;
        }
    }
    
}
