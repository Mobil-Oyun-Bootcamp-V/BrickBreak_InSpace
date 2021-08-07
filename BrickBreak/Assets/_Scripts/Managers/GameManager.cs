using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ASingleton<GameManager>
{
    PlayerController _playerController;
    public static int level { get; set; }
    public static int totalBulletCount { get; set; }
    public static int colliderBulletCount{ get; set; }
    public static bool firstEnemyControl{ get; set; }
    void Awake()
    {
        StartSingleton(this);
        _playerController = FindObjectOfType<PlayerController>();
        level = 1;
    }
    void Update()
    {
        if (PlayerManager.playerState == PlayerManager.PlayerState.EndMOD) 
        {   
            return; 
        }
        totalBulletCount = _playerController.ballCount;
        if (colliderBulletCount == totalBulletCount)
        {
            colliderBulletCount = 0;
            level++;
            PlayerManager.SetMOD("AimMOD");
            firstEnemyControl = false;
        }
    }
    public void SetPlayerHorMove(Transform pos)
    {
        _playerController.Move(pos.position);
    }

}
