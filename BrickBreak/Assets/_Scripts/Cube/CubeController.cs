using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class CubeController : AMoveDown
{
    public ModState mod;
    public enum ModState
    {
        Cube,
        Star
    }
    [field: SerializeField] public int point { get; set; }
    [field: SerializeField] public List<Sprite> sprites { get; private set; }
    [field: SerializeField] public List<int> levelBounds{ get; private set; }

    TextMeshPro pointText;

    Pool _cubePool;
    CubeSprite _cubeSprite;
    CubeAnimController _cubeAnimController;

    /////
    void Awake()
    {
        if (mod == ModState.Cube)
        {
            _cubePool = GameObject.FindGameObjectWithTag("CubePool").GetComponent<Pool>();
        }
        else
        {
            _cubePool = GameObject.FindGameObjectWithTag("StarPool").GetComponent<Pool>();

        }

        pointText = GetComponentInChildren<TextMeshPro>();
        _cubeSprite = new CubeSprite(this);
        _cubeAnimController = new CubeAnimController(this);
    }
    void OnEnable()
    {
        _cubeSprite.StartSprite();
        pointText.text = point.ToString();
    }
    void Update()
    {   
        _cubeSprite.ChangeSprite();
        OnMoveDownControl(1);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Bullet>() )
        {
            DecreasePoint();
        }
        if (collision.collider.CompareTag("BotGameLine"))
        {
            PlayerManager.SetMOD("EndMOD");
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<lazerPowerUP>())
        {
            DecreasePoint();
        }
    }
    /////
    public void DecreasePoint()
    {
        point--;
        pointText.text = point.ToString();
        _cubeAnimController.DamagedAnim();
        if (point < 1)
        {
            _cubePool.SetObject(this.gameObject);
        }
    }

}