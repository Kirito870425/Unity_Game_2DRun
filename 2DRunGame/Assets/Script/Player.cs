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
    
    public Animator catanimator;
    public Rigidbody2D rigi;
    public CapsuleCollider2D cap;
    #endregion

    #region 方法
    /// <summary>移動</summary>
    public void Move()
    {
        
    }
    /// <summary>跳躍</summary>
    public void Jump()
    {
        bool playerspace = Input.GetKeyDown(KeyCode.Space);
        catanimator.SetBool("CatJump", playerspace);
    }
    /// <summary>滑行</summary>
    public void Slider()
    {
        bool playerslider = Input.GetKeyDown(KeyCode.LeftControl);
        catanimator.SetBool("CatSllder", playerslider);

        //站 0  0          2 4.2
        //滑 0 -1.1      2 2
    }
    /// <summary>吃金幣</summary>
    public void EatCoin()
    {

    }
    /// <summary>受傷</summary>
    public void Hit()
    {

    }
    /// <summary>死亡</summary>
    public void Dead()
    {

    }
    /// <summary>過關</summary>
    public void Pass()
    {

    }
    #endregion

    #region 事件
    private void Update()
    {
        Jump();
        Slider();
    }
    #endregion

}
