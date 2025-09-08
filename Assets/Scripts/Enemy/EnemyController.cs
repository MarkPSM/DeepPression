using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Reference")]
    public LevelLoader levelLoader;
    public EnemySpawn enemySpawn;
    public CharacterController characterController;

    [Header("Animator")]
    private Animator animator;
    private bool isFacingRight = true;
    public bool isDead;

    [Header("AI")]
    public GameObject player;
    public float areaRange = 3f;
    public float speed = 10f;
    private Rigidbody2D rb;
    private Transform target;
    public bool canCollide;

    [Header("Stage")]
    public EnemySpawn.Stage thisStage;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = player.transform;
        canCollide = true;
    }

    void Update()
    {
        if (!isDead)
        {
            if (target.position.x < transform.position.x && isFacingRight)
                Flip();
            else if (target.position.x > transform.position.x && !isFacingRight)
                Flip();
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            float distance = Vector2.Distance(target.position, transform.position);

            if (distance <= areaRange && distance >= 2f)
            {
                Vector2 direction = (target.position - transform.position).normalized;
                rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

                animator.SetBool("isWalking", true);
            }
            else if (distance <= 2f)
            {
                rb.MovePosition(rb.position);
                animator.SetBool("isWalking", false);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
            
        }
        if (isDead)
        {
            animator.SetBool("isDead", true);
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canCollide == true)
        {
            if (collision != null && collision.gameObject == player)
            {
                if (enemySpawn != null)
                {
                    enemySpawn.actualStage = thisStage;
                    Debug.Log(enemySpawn.actualStage);
                    StartCoroutine(levelLoader.LoadCombatScene());
                    characterController.canWalk = false;
                    canCollide = false;
                }
                else {
                    Debug.Log("enemySpawn vazio");
                }
            }
        }
    }
}
