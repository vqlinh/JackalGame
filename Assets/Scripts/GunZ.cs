using UnityEngine;

public class GunZ : MonoBehaviour
{
    public Transform FireposZ;
    public float TimeFire = 0.2f;
    public float BulletForce;
    public GameObject Bullet;
    private float timeFire;

    void Update()
    {
        timeFire -= Time.deltaTime;
        if (Input.GetKey((KeyCode)'z') && timeFire < 0) FireBulelt();

    }

    void FireBulelt()
    {
        timeFire = TimeFire;
        GameObject BulletTmp = Instantiate(Bullet, FireposZ.position, Quaternion.identity);
        Rigidbody2D rb = BulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * BulletForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gate")|| collision.gameObject.CompareTag("Crep"))
            collision.gameObject.SetActive(false);
    }
}

