using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 5;
    [Header("跳越高度"), Range(0, 1000)]
    public int jump = 320;
    [Header("血量"), Range(0, 2000)]
    public float hp = 500;
    public bool isGround;
    public int coin;

    [Header("音效區域")]
    public AudioClip soundHit;
    public AudioClip soundSlide;
    public AudioClip soundJump;
    public AudioClip soundCoin;
    
    public Animator ani;
    public Rigidbody2D rigi;
    public CapsuleCollider2D cap;
    #endregion

    #region 方法
    public void PlayerMove()
    {
        
    }
    public void PlayerJump()
    {

    }
    public void PlayerSlider()
    {

    }
    public void EatCoin()
    {

    }
    public void PlayerHit()
    {

    }
    public void PlayerDead()
    {

    }
    public void PlayerGO()
    {

    }
    #endregion

    #region 事件

    #endregion

}
