using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public float speed; // Tốc độ di chuyển của enemy

    private Vector3 playerPosition;
    private Vector3 EnemyPos;
    public GameObject Bullet;
    public Transform ShootPos;
    public float Force;
    public float FireRate;
    float nextTimeToFire = 0;
    public float shootingDistance = 5f;

    void Update()
    {
        // Lấy vị trí hiện tại của enemy
        EnemyPos = transform.position;

        // Lấy vị trí của player từ đối tượng có tag "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerPosition = player.transform.position;
        }

        // Di chuyển enemy đến vị trí của bạn
        float distanceToPlayer = Vector3.Distance(EnemyPos, playerPosition);
        if (distanceToPlayer <= shootingDistance && Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1 / FireRate;
            Shoot();
        }
        else
        {
            EnemyPos = Vector3.MoveTowards(EnemyPos, playerPosition, speed * Time.deltaTime);
            transform.position = EnemyPos;
        }

        // Cập nhật vị trí mới cho enemy
        transform.position = EnemyPos;
    }

    void Shoot()
    {
        // Viết code để bắn vào player ở đây
        Vector2 Direction = (playerPosition - ShootPos.position).normalized;
        GameObject BulletIns = Instantiate(Bullet, ShootPos.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }
}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//namespace io.lockedroom.Games.Jackal
//{

//    public class enemyAI : MonoBehaviour
//    {
//        /// <summary>
//        /// Value of bullet speed
//        /// </summary>
//        public float Speed;
//        /// <summary>
//        /// value of vector 2 of target position
//        /// </summary>
//        private Transform TargetPosition;
//        /// <summary>
//        /// value of the distance of bulllet
//        /// </summary>
//        public float MaxBulletHeight;
//        public bool IsMoving;
//        // Start is called before the first frame update
//        void Start()
//        {
//            TargetPosition = GameObject.FindGameObjectWithTag("Player").transform;
//            IsMoving = true;
//        }

//        // Update is called once per frame
//        void Update()
//        {
//            if (IsMoving)
//            {
//                transform.position = Vector2.MoveTowards(transform.position, TargetPosition.position, Speed * Time.deltaTime);
//            }
//            BulletLifeTime();
//        }
//        private void BulletLifeTime()
//        {
//            Destroy(gameObject, 1f);
//        }
//    }
//}
