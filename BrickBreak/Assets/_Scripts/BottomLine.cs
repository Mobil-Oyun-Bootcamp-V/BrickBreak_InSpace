using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomLine : MonoBehaviour
{
    PlayerController _playerController;
    ObjectPool _objectPool;
    bool oneEnemyControl;
    GameObject bullet;
    
    void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _objectPool = FindObjectOfType<ObjectPool>();    
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        bullet = collision.gameObject;
        
        if (!oneEnemyControl)
        {
            if (bullet)
            {
                oneEnemyControl = true;
                StartCoroutine(_playerController.SetXPosition(bullet.transform.position));
            }
        }
         bullet.SetActive(false);
        _objectPool.queue.Enqueue(bullet);
    }
}
