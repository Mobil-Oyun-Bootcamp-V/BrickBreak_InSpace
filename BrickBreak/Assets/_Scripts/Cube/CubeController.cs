using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [field: SerializeField] public int point { get; private set; }
    [field: SerializeField] public List<Sprite> sprites { get; private set; }
    TextMeshPro pointText;

    CubeSprite _cubeSprite;
    CubeAnimController _cubeAnimController;
    
    /////
    void Awake()
    {
        pointText = GetComponentInChildren<TextMeshPro>();
        _cubeSprite = new CubeSprite(this);
        _cubeAnimController = new CubeAnimController(this);
    }
    void Start()
    {
        pointText.text = point.ToString();
        _cubeSprite.StartSprite();
    }
    void Update()
    {
        _cubeSprite.ChangeSprite();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        DecreasePoint();
        _cubeAnimController.DamagedAnim();
    }
    /////
    void DecreasePoint()
    {
        point--;
        pointText.text = point.ToString();
    }

}