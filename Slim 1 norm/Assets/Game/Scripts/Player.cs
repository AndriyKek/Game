using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animator anim;

    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;
    public GameObject Life4;
    public GameObject Life5;

    public float speed;       //швидкість
    public float jumpForсe;   //сила стрибку
    public float moveInput;   //рух натиснення
    public int Life = 5;

    public Rigidbody2D rb;               //по дефолту
    private bool facingRight = true;

    private bool isGrounded;              //перевіряє чи на землі
    public Transform groundCheck;         //є чи немає землі
    public float checkRadius;             //радіус дотику
    public LayerMask whatisGround;
    private int extraJumps;               //умови для прижка
    public int extraJumpsValue;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();   //по дефолту
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);  //перевірка всіх умов що до землі

        anim.SetBool("Ground", isGrounded);

        anim.SetFloat("vSpeed", rb.velocity.y);

        moveInput = Input.GetAxis("Horizontal");                     // горизонтальне (в право вліво)
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(moveInput));

        if (facingRight == false && moveInput < 0)                 //умова обертання персонажа
        {
            Flip();
        }
        else if (facingRight == true && moveInput > 0)
        {
            Flip();
        }

       

    
    }

    void OnTriggerEnter2D(Collider2D llife)     //llife просто назва відрізняється від нижнього бо там трігер треба ставити.
    {
        if (llife.gameObject.tag == "AddHp" && Life < 5)   //  AddHp  тег тут якщо персонаж маэ 3 хп то більше неможе підібрати сердець.
        {
            Life++;
            Destroy(llife.gameObject);                    //знищуэ обэкт після доторкання або після умови
        }
    }

    void OnCollisionEnter2D(Collision2D llife)     //llife просто назва
    {
        //.............................................

        /////////////////////
        //вхід на платформу//
        /////////////////////
        
        if (llife.gameObject.tag == ("Platform"))
        {
            this.transform.parent = llife.transform;
        }

        //...............................................
        if (llife.gameObject.tag == ("cyrk"))
        {
            Life--;

        }
        if (llife.gameObject.tag == "Kilok")
        {
            Life--;
            Life--;
        }
        if (Life <= 0)                                        //якщо життя буде <= 0 то scene перезапуститься
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;

            Life1.gameObject.SetActive(false);
            Life2.gameObject.SetActive(false);
            Life3.gameObject.SetActive(false);
            Life4.gameObject.SetActive(false);
            Life5.gameObject.SetActive(false);
        }
        if (Life == 5)
        {
            Life1.gameObject.SetActive(true);
            Life2.gameObject.SetActive(true);
            Life3.gameObject.SetActive(true);
            Life4.gameObject.SetActive(true);
            Life5.gameObject.SetActive(true);
        }
            if (Life == 4)
        {
            Life1.gameObject.SetActive(false);
            Life2.gameObject.SetActive(true);
            Life3.gameObject.SetActive(true);
            Life4.gameObject.SetActive(true);
            Life5.gameObject.SetActive(true);
        }
        if (Life == 3)
        {
            Life1.gameObject.SetActive(false);
            Life2.gameObject.SetActive(false);
            Life3.gameObject.SetActive(true);
            Life4.gameObject.SetActive(true);
            Life5.gameObject.SetActive(true);
        }
        if (Life == 2)
        {
            Life1.gameObject.SetActive(false);
            Life2.gameObject.SetActive(false);
            Life3.gameObject.SetActive(false);
            Life4.gameObject.SetActive(true);
            Life5.gameObject.SetActive(true);
        }
        if (Life == 1)
        {
            Life1.gameObject.SetActive(false);
            Life2.gameObject.SetActive(false);
            Life3.gameObject.SetActive(false);
            Life4.gameObject.SetActive(false);
            Life5.gameObject.SetActive(true);
        }

    }

   

        void Flip()                            //обертаэ персонажа
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


    /////////////////////
    //вихід з платформи//
    /////////////////////
    
    private void OnCollisionExit2D(Collision2D kek)
    {
        if (kek.gameObject.tag == ("Platform"))
        {
            this.transform.parent = null;
        }
    }


    void Update()
    {
        {
            if (isGrounded == true)
            {
                extraJumps = extraJumpsValue;
            }



            if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)   //кнопка стрибка
            {
                anim.SetBool("Ground", false);

                rb.velocity = Vector2.up * jumpForсe;
                extraJumps--;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForсe;
            }

        }
    }

}
