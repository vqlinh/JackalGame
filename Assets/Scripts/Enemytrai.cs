using UnityEngine;

public class Enemytrai : MonoBehaviour
{
    public float Speed;
    private float rightPos;
    private Animator EnemyAI;
    bool isOnenable = false;

    void Start()
    {
        EnemyAI = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        isOnenable = true;
    }

    public void SetRightPos(float pos)
    {
        rightPos = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Nhadantrai nhadanScript = FindObjectOfType<Nhadantrai>();
            if (nhadanScript != null) nhadanScript.SpawnNextEnemy();
        }
    }

    void Update()
    {
        if (isOnenable)
        {
            if (transform.localPosition.x < rightPos)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(rightPos, transform.localPosition.y), Speed * Time.deltaTime);
                EnemyAI.SetBool("Enemytrai", false);

                if (transform.localPosition.x >= rightPos)
                {
                    gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
                    EnemyAI.SetBool("Enemytrai", true);
                }
            }
        }
    }
}
