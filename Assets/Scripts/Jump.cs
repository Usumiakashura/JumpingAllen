using UnityEngine;

public class Jump : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private bool isGrounded = true;
    private float checkRadius = 0.5f;   //радиус вокруг groundCheck, который будет проверяться
    [SerializeField] private Transform groundCheck = null;  //точка проверки находится ли персонаж на земле

    [SerializeField] private GameObject touchMonitor = null;
    
    private int jumpsCount;         //подсчет прыжков

    public int jumps;               //кол-во прыжков
    public float jumpForce;         //сила прыжка
    public LayerMask whatIsGround;  //то, что считается за землю


    private float playerPositionY;        //переменные для счета платформ

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        jumpsCount = jumps;

        playerPositionY = rb.position.y + 2f;   //точка для подсчета пройденных платформ
    }

    private void Update()
    {
        if (isGrounded == true)
        {
            if (rb.velocity.magnitude == 0)     //проверка на то, стоит ли персонаж при касании с землей
            {
                animator.SetBool("isJump", false);
                jumpsCount = jumps;
                if (playerPositionY < rb.position.y)    //if для подсчета пройденных платформ
                {
                    GetComponent<ScoreCalculate>().ScoreUp();   //вызывает метод подсчета платформ
                    playerPositionY = rb.position.y + 2f;
                }
            }
        }
        else
        {
            animator.SetBool("isJump", true);
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (touchMonitor.GetComponent<Touch>().Touches > 0)
        {
            if (jumpsCount > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpsCount--;
            }
            touchMonitor.GetComponent<Touch>().Touches = 0;
        }
    }

}
