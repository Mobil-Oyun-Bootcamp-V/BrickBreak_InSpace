using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
  public static PlayerState playerState;
  public enum PlayerState
    {   
        FireMOD,
        PlayingMOD
    }
}
