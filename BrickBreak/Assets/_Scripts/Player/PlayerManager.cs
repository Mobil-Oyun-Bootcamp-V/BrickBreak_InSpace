using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
  public static PlayerState playerState;
  public enum PlayerState
    {   
        AimMOD,
        FireMOD,
        PlayingMOD
    }
     public static void SetMOD(string key)
    {
        switch (key)
        {
            case "AimMOD":
                playerState = PlayerState.AimMOD;
                break;

            case "FireMOD":
                playerState = PlayerState.FireMOD;
                break;

            case "PlayingMOD":
                playerState = PlayerState.PlayingMOD;
                break;
        }
    }
    
}
