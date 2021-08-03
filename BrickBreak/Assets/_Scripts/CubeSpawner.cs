using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] Pool _cubePool;
    [SerializeField] int pointMaxBound;
    bool IsSpawn;

    void Update()
    {
        if (PlayerManager.playerState == PlayerManager.PlayerState.AimMOD)
        {
            if (IsSpawn)
            {
                return;
            }
            Spawn();
            IsSpawn = true;
        }
        else 
        {
            IsSpawn = false;
        }
    }

    public void Spawn()
    {
        GameObject go =_cubePool.GetObject(transform);
        go.GetComponent<CubeController>().point = Random.Range(0, pointMaxBound);
    }
}
