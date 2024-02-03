using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public float checkRadius;
    public float attackRadius;

    public bool shouldRorate;

    public LayerMask whatisPlayer;

    private Transform target;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;
    private bool isDie = true;

    public float moveSpeed;
    public float minDistance;
    public float timeBetweenShots;
    public GameObject bullet;
    public Transform ShootPoint;
    public float range = 1f;
    Vector2 Direction;
    public float Force;

    private float shotCounter;
    private Rigidbody2D rb;
    int count = 0;
    int count1 = 0;
    private int defeatedBossCount = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        shotCounter = timeBetweenShots;
    }

    private void Update()
    {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatisPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatisPlayer);
        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        if (shouldRorate)
        {
            anim.SetFloat("X", dir.x);
            anim.SetFloat("Y", dir.y);
        }
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) < range)
        {
            if (isDie) transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        if (isInAttackRange)
        {
            if (Vector2.Distance(transform.position, target.position) < minDistance)
            {
                if (shotCounter <= 0)
                {
                    Vector2 targetPos = target.position;
                    Direction = targetPos - (Vector2)transform.position;
                    GameObject BulletIns = Instantiate(bullet, ShootPoint.position, transform.rotation);
                    BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
                    shotCounter = timeBetweenShots;
                }
                else shotCounter -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            count++;
            if (count==5)
            {
                isDie = false;
                Destroy(gameObject);
                GameManager.instance.AudioDestroyEnemy();
                defeatedBossCount++;
                Debug.Log(defeatedBossCount);
                if (defeatedBossCount == 5)
                {
                    // Tất cả boss đã bị tiêu diệt, chuyển sang scene "Win"
                    SceneManager.LoadScene("WinGame");
                }
            }
            
        }
        if (collision.gameObject.CompareTag("Grenade"))
        {
            count1++;
            if (count1==2)
            {
                isDie = false;
                Destroy(gameObject);
                GameManager.instance.AudioDestroyEnemy();
            }
        }
    }
}
