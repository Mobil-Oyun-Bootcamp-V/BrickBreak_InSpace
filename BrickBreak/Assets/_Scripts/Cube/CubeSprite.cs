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
        for(int i=0; i<levelBound.Count; i++)
        {
            if (point >= levelBound[i])
            {
                spriteIndex = i;
                break;
            }
        }
        _currentSprite.sprite = _cubeController.sprites[spriteIndex];
    }
    public void ChangeSprite() 
    {
        point = _cubeController.point;

        for(int i = 0; i < levelBound.Count; i++)
        {
            if (point == levelBound[i] - 1)
            {
                _currentSprite.sprite = _cubeController.sprites[i+1];
                break;
            }
        }
    }
}
