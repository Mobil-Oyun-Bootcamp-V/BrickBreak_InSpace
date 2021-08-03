using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{ 
    PlayerController _playerController;
    Touch touch;

    Vector2 firstPos;
    float difY;
    public PlayerInput(PlayerController playerController)
    {
        _playerController = playerController;
    }
    public float Active()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    difY = 0;
                    firstPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    difY = touch.position.y - firstPos.y;
                    break;
                case TouchPhase.Ended:
                    PlayerManager.SetMOD("FireMOD");
                    break;
            }
        }
        return difY / 2;
    }
    
}
