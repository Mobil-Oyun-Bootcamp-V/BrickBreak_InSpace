using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeController : MonoBehaviour
{   
    [field: SerializeField] public int point { get; set; }
    [field: SerializeField] public List<Sprite> sprites { get; private set; }
    [field: SerializeField] public List<int> levelBounds{ get; private set; }

    TextMeshPro pointText;

    Pool _cubePool;
    CubeSprite _cubeSprite;
    CubeAnimController _cubeAnimController;

    bool IsMoved;

    
    /////
    void Awake()
    {
        _cubePool = GameObject.FindGameObjectWithTag("CubePool").GetComponent<Pool>();
        pointText = GetComponentInChildren<TextMeshPro>();
        _cubeSprite = new CubeSprite(this);
        _cubeAnimController = new CubeAnimController(this);
    }
    void Start()
    {
        pointText.text = point.ToString();
        SetupSprite();
    }
    void Update()
    {   
        _cubeSprite.ChangeSprite();
        if (PlayerManager.playerState == PlayerManager.PlayerState.AimMOD)
        {
            if (IsMoved)
            {
                return;
            }
            StartCoroutine(SupportClass.LerpMove(this.gameObject,transform.position,new Vector2(transform.position.x, transform.position.y - 1), 1));
            IsMoved= true;
        }
        else
        {
            IsMoved = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        DecreasePoint();
        _cubeAnimController.DamagedAnim();
        Dead();
    } 
    /////
    public void SetupSprite()
    {
        _cubeSprite.StartSprite();
    }
    //IEnumerator Move()
    //{
    //    float time = 0;
    //    Vector2 targetPos = new Vector2(transform.position.x, transform.position.y-2);
    //    while (time < 1)
    //    {
    //        transform.position = Vector2.Lerp(transform.position, targetPos, time / 1);
    //        time += Time.deltaTime;
    //        yield return null;
    //    }
    //    transform.position = targetPos;
    //}
    void Dead()
    {
        if (point == 0)
        {
           _cubePool.SetObject(this.gameObject);
        }
    }
    void DecreasePoint()
    {
        point--;
        pointText.text = point.ToString();
    }

}