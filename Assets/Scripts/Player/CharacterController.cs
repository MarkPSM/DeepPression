    using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Referência")]
    public CharacterManager characterManager;
    public GameObject player;

    [Header("Movimentação")]
    private Rigidbody2D rb;
    private float moveSpeed = 1f;
    public float currentSpeed;
    public bool canWalk;

    public Vector2 playerDirection;

    private bool isWalking = false;
    private Animator animator;
    public bool facingRight = true;
    private bool facingUp = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = characterManager.Speed / 10;
        currentSpeed = moveSpeed;

        animator = GetComponent<Animator>();

        canWalk = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

        UpdateAnimator();
    }

    private void FixedUpdate()
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
        if (canWalk)
        {
            playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (playerDirection.x < 0 && facingRight)
            {
                Flip();
            }
            else if (playerDirection.x > 0 && !facingRight)
            {
                Flip();
            }

            if (playerDirection.y < 0 && facingUp)
            {
                facingUp = !facingUp;
            }
            else if (playerDirection.y > 0 && !facingUp)
            {
                facingUp = !facingUp;
            }
        }
        else
        {
            isWalking = false;
            playerDirection = Vector2.zero;
        }

    }

    void Flip()
    {
        facingRight = !facingRight;

        player.transform.Rotate(0, 180, 0);
    }

    void UpdateAnimator()
    {
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isFacingUp", facingUp);
    }
}
