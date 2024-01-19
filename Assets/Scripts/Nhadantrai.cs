using System.Collections;
using UnityEngine;

public class Nhadantrai : MonoBehaviour
{
    private Animator nhadan;
    public GameObject enemytraiPrefab;
    private int numberOfEnemies = 3;
    private int enemiesSpawned = 0;
    bool isSpawn = false;

    void Start()
    {
        nhadan = GetComponent<Animator>();
        nhadan.SetBool("no", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grenade" && !isSpawn) // de cho viec chi va cham voi luu dan 1 lan
        {
            isSpawn = true;
            nhadan.SetBool("no", true);
            SpawnNextEnemy();
        }
    }

    public void SpawnNextEnemy()
    {
        if (enemiesSpawned < numberOfEnemies)
        {
            enemiesSpawned += 1;

            GameObject newEnemytrai = Instantiate(enemytraiPrefab, this.transform.position, Quaternion.identity);
            Enemytrai enemyScript = newEnemytrai.GetComponent<Enemytrai>();
            if (enemyScript != null)
            {
                enemyScript.SetRightPos(transform.position.x + 0.5f);
            }

            Debug.Log("enemiesSpawned" + enemiesSpawned);
        }

        if (enemiesSpawned >= numberOfEnemies)
        {
            isSpawn = true;
        }
    }
}
