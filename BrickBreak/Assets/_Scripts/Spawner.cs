using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPositions;
    [SerializeField] List<Pool> _currentPool;
    [SerializeField] [Range(0,100)] List<int> selectPossibility;
    [SerializeField] List<float> ResultPossibility;
    float []matchResult;
    bool IsSpawn;
    void Awake()
    {
        matchResult = new float[_currentPool.Count];
    }
    void Start()
    {
        CalculatePossibility();
    }
    void Update()
    {
        if (PlayerManager.playerState == PlayerManager.PlayerState.AimMOD)
        {
            if (IsSpawn)
            {
                return;
            }
            MatchSpawnControl();
            IsSpawn = true;
        }
        else 
        {
            IsSpawn = false;
        }
    }
    //Olasýlýða göre hangisine denk geldiði
    void MatchSpawnControl()
    {
        for(int i = 0; i < spawnPositions.Count; i++)
        {
            int rand = Random.Range(0,101);
            for(int x = 0; x <_currentPool.Count; x++)
            {
                if(rand < matchResult[x])
                {
                    SpawnObject(x,i);
                    break;
                }
            }
        }
    }
    //Objenin pooldan çekilme yeri
    void SpawnObject(int objIndex,int posIndex)
    {
        GameObject go = _currentPool[objIndex].GetObject(spawnPositions[posIndex]);
        if (go.GetComponent<CubeController>())
        {
            go.SetActive(false);
            go.GetComponent<CubeController>().point = GameManager.level;
            go.SetActive(true);
        }
    }
    //Spawn olasýlýklarý hesaplanýyor
    void CalculatePossibility()
    {
        float total=0;
        float unitValue;
        foreach(int val in selectPossibility)
        {
            total += val;
        }
        //yüzde 40 boþ gelme için ayrýldý
        unitValue = 60 / total;
        for (int i = 0; i < _currentPool.Count; i++)
        {
            ResultPossibility[i] = unitValue * selectPossibility[i];
           
            for(int z = 0; z <= i; z++)
            {
                matchResult[i] += ResultPossibility[z];
            }
        }
    }
}
