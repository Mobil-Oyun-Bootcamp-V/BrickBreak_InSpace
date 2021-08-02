using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSprite : MonoBehaviour
{
    CubeController _cubeController;
    SpriteRenderer _currentSprite;
    int spriteIndex;
    public CubeSprite(CubeController cubeController)
    {
        _cubeController = cubeController;
        _currentSprite = _cubeController.GetComponent<SpriteRenderer>();
    }

    public void StartSprite()
    {
        if (_cubeController.point >= 500)
        {
            spriteIndex = 0;
        }
        else if (_cubeController.point >= 250)
        {
            spriteIndex = 1;
        }
        else if (_cubeController.point >= 100)
        {
            spriteIndex = 2;
        }
        else
        {
            spriteIndex = 3;
        }
        _currentSprite.sprite = _cubeController.sprites[spriteIndex];
    }
    public void ChangeSprite() 
    {
        switch (_cubeController.point)
        {
            case 499:
                _currentSprite.sprite = _cubeController.sprites[1];
                break;

            case 249:
                _currentSprite.sprite = _cubeController.sprites[2];
                break;

            case 99:
                _currentSprite.sprite = _cubeController.sprites[3];
                break;
        }
    }
}
