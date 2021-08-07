using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerPowerUP : AMoveDown
{
    Animator _anim;
    Pool _laserPool;
    void Awake()
    {
        _laserPool = GameObject.FindGameObjectWithTag("LaserPUPool").GetComponent<Pool>();
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        OnMoveDownControl(1);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Bullet>())
        {
            EnableAttack();
            Invoke("GotoPool", 0.4f);
        }
        if (collision.collider.CompareTag("BotGameLine"))
        {
            _laserPool.SetObject(this.gameObject);
        }
    }
    void EnableAttack()
    {
        _anim.SetTrigger("IsLaser");
    }
    void GotoPool()
    {
        _laserPool.SetObject(this.gameObject);
    }
}
