using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    public float Range;
    public Transform Target;
    bool Detected = false;
    Vector2 Direction;
    public GameObject Gun;
    public GameObject Bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform ShootPos;
    public float Force;
    private int count = 0;

    void Update()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range,1<<LayerMask.NameToLayer("Player"));
        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if (Detected == false) Detected = true;
                else Detected = false;
            }
        }
        if (Detected)
        {
            if (Time.time > nextTimeToFire)
            {
                Gun.transform.up = Direction;
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
                Detected = false; // ngừng phát hiện mục tiêu để quay lại vị trí của player
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grenade")|| collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Bullet")) count++;
        if (count==3) gameObject.SetActive(false);
    }

    void shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, ShootPos.position, Quaternion.identity);
        Vector2 directionNormalized = Direction.normalized;
        BulletIns.GetComponent<Rigidbody2D>().AddForce(directionNormalized * Force);
        // Lưu giá trị Direction vào biến tạm
        Vector2 tempDirection = Direction;
        // Gọi đệ quy
        StartCoroutine(ShootAgain(tempDirection));
    }

    IEnumerator ShootAgain(Vector2 direction)
    {
        // Chờ 0,25 giây
        yield return new WaitForSeconds(0.2f);

        // Normalize the direction vector
        Vector2 directionNormalized = direction.normalized;

        // Bắn một viên đạn khác theo hướng của viên đạn đầu tiên
        GameObject BulletIns = Instantiate(Bullet, ShootPos.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(directionNormalized * Force);

        // Chờ 0,25 giây
        yield return new WaitForSeconds(0.2f);

        // Bắn thêm một viên đạn theo hướng của viên đạn đầu tiên
        GameObject BulletIns2 = Instantiate(Bullet, ShootPos.position, Quaternion.identity);
        BulletIns2.GetComponent<Rigidbody2D>().AddForce(directionNormalized * Force);
    }

}