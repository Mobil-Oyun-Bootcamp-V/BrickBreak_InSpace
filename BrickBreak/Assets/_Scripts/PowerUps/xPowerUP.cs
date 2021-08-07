using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xPowerUP : AMoveDown
{
    Pool _xPowerUpPool;
    void Awake()
    {
        _xPowerUpPool = GameObject.FindGameObjectWithTag("xPUPool").GetComponent<Pool>();
    }
    void Update()
    {
        OnMoveDownControl(1);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Bullet>() || collision.collider.CompareTag("BotGameLine"))
        {
            _xPowerUpPool.SetObject(this.gameObject);
        }
    }
}
