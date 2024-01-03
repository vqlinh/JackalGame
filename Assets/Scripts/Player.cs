using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float MoveSpeed;
    public Vector3 MoveInput;
    // public Animator animator;
    public SpriteRenderer CharacterSR;

    private void Start() {
        rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveInput.x = Input.GetAxis("Horizontal");
        MoveInput.y = Input.GetAxis("Vertical");
        rb.velocity = MoveInput.normalized * MoveSpeed;
        if (MoveInput != Vector3.zero)
        {
            float angle = Mathf.Atan2(MoveInput.y, MoveInput.x) * Mathf.Rad2Deg;
            CharacterSR.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BulletAI") || collision.gameObject.CompareTag("BulletTank"))
        {
            this.gameObject.SetActive(false);
            GameOver();
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
