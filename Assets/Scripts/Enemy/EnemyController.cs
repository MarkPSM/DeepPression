using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int ID;

    [Header("Reference")]
    public LevelLoader levelLoader;
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
    public bool isBoss;

    [Header("Stage")]
    public EnemySpawn.Stage thisStage;

    private void Awake()
    {
        canCollide = true;
        target = player.transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isDead = EnemyManager.Enemy.isDead;

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
            StartCoroutine(Death());
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
                GameManager.Instance.PrepareCombat(thisStage);
                StartCoroutine(levelLoader.LoadPhase("CombatScene"));

                EnemyManager.Enemy.actualID = ID;
            }
        }
        else
        {
            Debug.Log("Collision = null");
        }
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("isDead", true);
        yield return new WaitForSeconds(2f);

        Destroy(this.gameObject);
    }
}
