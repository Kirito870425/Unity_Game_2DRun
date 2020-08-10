using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 10)]
    public float speed = 5;
    [Header("跳越高度"), Range(0, 1000)]
    public int jump = 320;
    [Header("血量"), Range(0, 2000)]
    public float hp = 500;
    private float hpmax = 500;
    public Image imagehp;
    private bool dead;
    private bool isGround;

    [Header("音效區域")]
    public AudioClip soundHit;
    public AudioClip soundSlide;
    public AudioClip soundJump;
    public AudioClip soundCoin;
    public AudioSource audiojump;
    [Header("其他區域")]
    public Text textcoin;
    public Animator catanimator;
    public Rigidbody2D rg;
    public CapsuleCollider2D cap;
    public GameObject final;
    public int coin;


    #endregion

    #region 方法
    /// <summary>移動</summary>
    public void Move()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    /// <summary>跳躍</summary>
    public void Jump()
    {
        bool playerspace = Input.GetKeyDown(KeyCode.Space);
        // 2射線碰撞物體 2D物理.射線碰撞(起點, 方向, 長度, 圖層(比Tag多"物理"判定))
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -2.1f), -transform.up, 0.1f, 1 << 8);

        if (hit)
        {
            isGround = true;
            catanimator.SetBool("CatJump", false);
        }
        else
        {
            isGround = false;
        }

        if (isGround)
        {
            if (playerspace)
            {
                audiojump.PlayOneShot(soundJump);
                catanimator.SetBool("CatJump", true);
                rg.AddForce(new Vector2(0, jump));
            }

        }
    }

    /// <summary>滑行</summary>
    public void Slider()
    {
        bool playerslider = Input.GetKey(KeyCode.LeftControl);
        catanimator.SetBool("CatSllder", playerslider);

        if (Input.GetKeyDown(KeyCode.LeftControl))
            audiojump.PlayOneShot(soundSlide);

        //按下左CTRL滑行變更碰撞器大小
        if (playerslider)
        {
            //滑 0 -1.1      2 2
            cap.offset = new Vector2(0, -1.1f);
            cap.size = new Vector2(2f, 2f);
        }
        else
        {
            //站 0  0          2 4.2
            cap.offset = new Vector2(0, 0);
            cap.size = new Vector2(2f, 4.2f);
        }
    }
    /// <summary>吃金幣</summary>
    public void EatCoin(GameObject objcoin)
    {
        coin++;
        audiojump.PlayOneShot(soundCoin);
        textcoin.text = "金幣：" + coin;
        Destroy(objcoin, 0);    //Object不用開頭. ,延遲
    }
    /// <summary>受傷</summary>
    public void Hit(GameObject objhit)
    {
        hp -= 100;
        audiojump.PlayOneShot(soundHit);
        imagehp.fillAmount = hp / hpmax;
        Destroy(objhit);

        if (hp <= 0) Dead();
    }

    /// <summary>死亡</summary>
    public void Dead()
    {
        catanimator.SetTrigger("CatDead");
        final.SetActive(true);
        speed = 0;
        dead = true;
        texttitle.text = "還差的遠呢 嫩";
    }
    public Text texttitle;
    public Text textfinalcoin;

    /// <summary>過關</summary>
    public void Pass()
    {
        speed = 0;
        final.SetActive(true);
        texttitle.text = "恭喜你過關RRRRRR";
        textfinalcoin.text = "本次金幣數量" + coin;
    }
    #endregion

    #region 事件
    private void Start()
    {
        hpmax = hp;
    }

    private void Update()
    {
        if (dead) return;   //return以下不會執行
        if (transform.position.y <= -6f) Dead();

        Move();
        Jump();
        Slider();
    }

    /// <summary>繪製圖示:繪製輔助線條，僅Scene</summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        //角色中心(起點，方向)
        //up,right,forward 上y，右x，前z
        //DrawRay 畫線
        //DrawLine 點對點
        Gizmos.DrawRay(transform.position + new Vector3(0, -2.1f), -transform.up * 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "金幣")
            EatCoin(collision.gameObject);
        if (collision.tag == "陷阱")
            Hit(collision.gameObject);
        if (collision.name == "傳送門")
            Pass();
    }
    //enter 進入執行一次
    //exit 離開
    //stay 持續執行 60FPS
    #endregion

}
