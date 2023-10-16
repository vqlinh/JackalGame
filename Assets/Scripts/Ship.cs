using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float Speed;
    public float DownPos;
    public bool MovingBot;
    public GameObject Bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform ShootPos;
    public float Force;
    public bool IsMoving;
    public float AttackDistance;
    private Transform TargetPosition;
    // Start is called before the first frame update
    void Start()
    {
        TargetPosition = GameObject.FindGameObjectWithTag("Player").transform;
        IsMoving = true;
    }
    
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grenade")|| collision.gameObject.CompareTag("Bullet"))
        {
            this.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, TargetPosition.position); // vi tri cua nhan vat va crep
        if (distance <= AttackDistance) // check if distance is less than or equal to AttackDistance
        {
            if (transform.localPosition.y > DownPos) // Nếu chưa đi hết xuống dưới
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, DownPos), Speed * Time.deltaTime);

                if (transform.localPosition.y <= DownPos)
                {
                    MovingBot = true;
                }
            }



            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
           
        }


      
        void shoot()
        {
            GameObject BulletIns = Instantiate(Bullet, ShootPos.position, Quaternion.identity);
            Vector2 direction = (TargetPosition.position - ShootPos.position).normalized;
            BulletIns.GetComponent<Rigidbody2D>().AddForce(direction * Force);
            // Gọi đệ quy
        }
    }

}
