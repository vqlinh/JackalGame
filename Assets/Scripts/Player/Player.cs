using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed;
    public Vector2 movementInput;
    //public Vector3 MoveInput;
    public Animator animator;
    public SpriteRenderer CharacterSR;

    private void Start() {
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Animate();
        //MoveInput.x = Input.GetAxis("Horizontal");
        //MoveInput.y = Input.GetAxis("Vertical");
        //rb.velocity = MoveInput.normalized * MoveSpeed;
        //if (MoveInput != Vector3.zero)
        //{
        //    float angle = Mathf.Atan2(MoveInput.y, MoveInput.x) * Mathf.Rad2Deg;
        //    CharacterSR.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        //}
        if (movementInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(movementInput.y, movementInput.x) * Mathf.Rad2Deg;
            CharacterSR.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle -90));
        }
    }

    public void Move()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        if (Horizontal==0 && Vertical==0)
        {
            rb.velocity= new Vector2 (0,0);
            return;
        }
        movementInput = new Vector2 (Horizontal, Vertical).normalized;
        rb.velocity = movementInput *moveSpeed*Time.fixedDeltaTime;
    }
    public void Animate()
    {
        animator.SetFloat("MovementX",movementInput.x);
        animator.SetFloat("MovementY",movementInput.y);
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BulletEnemy") || collision.gameObject.CompareTag("BulletTank"))
        {
            this.gameObject.SetActive(false);
            GameOver();
            collision.gameObject.SetActive(false);
        }
    }

    private void GameOver()
    {
        Invoke("ReloadScene", 2f);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("LV1");
    }
}
