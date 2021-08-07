using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plusPowerUP : AMoveDown
{
    PlayerController _playerController;
    Pool _plusPowerUpPool,_bulletPool;
    
    void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _plusPowerUpPool = GameObject.FindGameObjectWithTag("PlusPUPool").GetComponent<Pool>();
        _bulletPool = GameObject.FindGameObjectWithTag("BulletPool").GetComponent<Pool>();
    }
    void Update()
    {
        OnMoveDownControl(1);     
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Bullet>())
        {
            PushBall();
            _plusPowerUpPool.SetObject(this.gameObject);
        }
        if (collision.collider.CompareTag("BotGameLine"))
        {
            _plusPowerUpPool.SetObject(this.gameObject);
        }
    }
    void PushBall()
    {
        GameObject go = _bulletPool.GetObject(transform);
        go.SetActive(true);
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        rb.AddForce(this.gameObject.transform.up * 10 * 50);
        _playerController.ballCount++;
    }
}
