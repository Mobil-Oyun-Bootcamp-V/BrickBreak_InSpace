using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] protected Transform spawnPoint;
    [SerializeField] protected GameObject weapon;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected float horizontalSpeed;
    [field: SerializeField] public int ballCount { get; set; }
}
