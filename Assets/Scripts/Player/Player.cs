using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;
    private Quaternion _targetRotation;

    Rigidbody2D rb;
    public float moveSpeed;
    Vector2 movementInput;
    Animator animator;
    public SpriteRenderer CharacterSR;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _targetRotation = transform.rotation;
    }

    void Update()
    {
        Move();
        Animate();
        if (movementInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(movementInput.y, movementInput.x) * Mathf.Rad2Deg;
            CharacterSR.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }
        
    }

    public void Move()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        if (Horizontal == 0 && Vertical == 0)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }
        movementInput = new Vector2(Horizontal, Vertical).normalized;
        rb.velocity = movementInput * moveSpeed * Time.fixedDeltaTime;
        Vector2 direction = new Vector2(Horizontal, Vertical);
        if (direction.magnitude > 0.1f)
            transform.rotation = Quaternion.Lerp(transform.rotation, GetTargetRotation(direction), rotationSpeed * Time.deltaTime);

    }
        private Quaternion GetTargetRotation(Vector2 direction)
    {
        return Quaternion.LookRotation(Vector3.forward, direction);
    }
    public void Animate()
    {
        animator.SetFloat("MovementX", movementInput.x);
        animator.SetFloat("MovementY", movementInput.y);
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