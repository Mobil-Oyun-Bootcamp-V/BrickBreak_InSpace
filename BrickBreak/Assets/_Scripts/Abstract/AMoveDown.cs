using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AMoveDown : MonoBehaviour
{
    protected bool IsMoved;
    protected void OnMoveDownControl(float time) 
    {
        if (PlayerManager.playerState == PlayerManager.PlayerState.AimMOD)
        {
            if (IsMoved)
            {
                return;
            }
            StartCoroutine(SupportClass.LerpMove(this.gameObject, transform.position, new Vector2(transform.position.x, transform.position.y - 1), time));
            IsMoved = true;
        }
        else
        {
            IsMoved = false;
        }
    }
}
