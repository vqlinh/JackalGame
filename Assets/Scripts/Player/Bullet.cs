using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private float lifeTime;
    void Start()
    {
        Invoke(nameof(Impact), lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Impact();

    }

    private void Impact()
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bot")){
            this.gameObject.SetActive(false);
        }
    }
}
