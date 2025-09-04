using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject player;

    public int maxHP;
    public int actualHP;

    public int maxMP;
    public int actualMP;

    [Header("Atributos")]
    public int Attack;
    public int mentalAttack;
    public int Defense;
    public int Speed;

    [Header("Movimentação")]
    private Rigidbody2D rb;
    private float moveSpeed = 1f;
    public float currentSpeed;

    public Vector2 playerDirection;

    public bool isWalking = false;
    //private Animator animator;
    private bool facingRight = true;
    //private bool facingUp = false;
    //private bool facingDown = false;
    //private bool facingLeft = false;


    private void Awake()
    {
        maxHP = 100;
        actualHP = 100;

        Debug.Log($"actualHP:{actualHP} / maxHP:{maxHP}");

        maxMP = 20;
        actualMP = 20;

        Attack = 5;
        mentalAttack = 1;
        Defense = 1;
        Speed = 20;

        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Speed / 10;
        currentSpeed = moveSpeed;
    }

    void Update()
    {
        PlayerMove();
    }

    void FixedUpdate()
    {
        if (playerDirection.x != 0 || playerDirection.y != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

            rb.MovePosition(rb.position + currentSpeed * Time.fixedDeltaTime * playerDirection);
    }

    void PlayerMove()
    {
        playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (playerDirection.x < 0 && facingRight)
        {
            Flip();
        }
        else if (playerDirection.x > 0 && !facingRight) {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0, 180, 0);
    }
}
