﻿using System.Collections;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    Vector2 Direction;
    public float Range;
    public float Force;
    private int count = 0;
    bool Detected = false;
    public float FireRate;
    public GameObject Gun;
    public Transform Target;
    public GameObject Bullet;
    float nextTimeToFire = 0;
    public Transform ShootPos;
    public GameObject bumEffect;

    void Update()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range, 1 << LayerMask.NameToLayer("Player"));
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
        if (collision.gameObject.CompareTag("Grenade") || collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            GameManager.instance.AudioDestroyTank();
            GameObject effect = Instantiate(bumEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GameManager.instance.AudioBulletAttack();
            count++;
        }
        if (count == 3)
        {
            gameObject.SetActive(false);
            GameManager.instance.AudioDestroyTank();
            GameObject effect = Instantiate(bumEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }
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