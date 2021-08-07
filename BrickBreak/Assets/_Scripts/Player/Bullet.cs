using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    Pool _bulletPool;
    GameManager _gameManager;
    float collisionTime;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _bulletPool = GameObject.FindGameObjectWithTag("BulletPool").GetComponent<Pool>();
        _gameManager = FindObjectOfType<GameManager>();
    }
    void OnEnable()
    {
        collisionTime = Time.time;
    }
    void Update()
    {
        if (PlayerManager.playerState != PlayerManager.PlayerState.PlayingMOD)
        {
            return;
        }
        if (Time.time > collisionTime + 7)
        {
            BugConstMovement();
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<CubeController>())
        {
            collisionTime = Time.time;
        }
        if (collision.collider.CompareTag("BotGameLine"))
        {
            GameManager.colliderBulletCount++;
            _bulletPool.SetObject(this.gameObject);
            if (!GameManager.firstEnemyControl)
            {
                GameManager.firstEnemyControl = true;
                _gameManager.SetPlayerHorMove(this.transform);
            }
        }
    }
    //7 saniye sabit kalýrsa devreye giriyor.
    void BugConstMovement()
    {
        rb.AddForce(Vector2.down * 10);
    }
}
