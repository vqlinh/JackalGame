using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Bot : MonoBehaviour
{
    public float checkRadius;
    public float attackRadius;

    public bool shouldRorate;

    public LayerMask whatisPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    public float moveSpeed;
    public float minDistance;
    public float timeBetweenShots;
    public GameObject bullet;
    public Transform ShootPoint;
    public float range = 1f;
    Vector2 Direction;
    public float Force;

    private float shotCounter;
    public float Timetodie;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        shotCounter = timeBetweenShots;
    }
    private void Update()
    {
        anim.SetBool("IsRun", isInChaseRange);
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
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
           
        }
       
        if (isInAttackRange)
        {
            // rb.velocity = Vector2.zero;

            if (Vector2.Distance(transform.position, target.position) < minDistance)
            {
                if (shotCounter <= 0)
                {
                    Vector2 targetPos = target.position;
                    Direction = targetPos - (Vector2)transform.position;
                    GameObject BulletIns = Instantiate(bullet, ShootPoint.position, Quaternion.identity);
                    BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
                    shotCounter = timeBetweenShots;
                }
                else
                {
                    shotCounter -= Time.deltaTime;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") )
        {
            anim.SetBool("IsDie", true);

            Destroy(gameObject, Timetodie);
            Destroy(collision.gameObject);
        }
        if ( collision.gameObject.CompareTag("Grenade") || collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("IsDie", true);
            Destroy(gameObject, Timetodie);

        }

    }

}