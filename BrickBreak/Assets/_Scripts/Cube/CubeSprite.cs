using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSprite : MonoBehaviour
{
    CubeController _cubeController;
    SpriteRenderer _currentSprite;
    
    int spriteIndex;
    int point;
    List<int> levelBound;
    public CubeSprite(CubeController cubeController)
    {   
        _cubeController = cubeController;
        levelBound = _cubeController.levelBounds;
        _currentSprite = _cubeController.GetComponent<SpriteRenderer>();
    }

    public void StartSprite()
    {
        point = _cubeController.point;

        if (point >= levelBound[0])
        {
            spriteIndex = 0;
        }
        else if (point >= levelBound[1])
        {
            spriteIndex = 1;
        }
        else if (point >= levelBound[2])
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
        point = _cubeController.point;

        if (point == levelBound[0]-1)
        {
            _currentSprite.sprite = _cubeController.sprites[1];
        }
        else if (point == levelBound[1]-1)
        {
            _currentSprite.sprite = _cubeController.sprites[2];
        }
        else if (point == levelBound[2]-1)
        {
            _currentSprite.sprite = _cubeController.sprites[3];
        }

    }
}
