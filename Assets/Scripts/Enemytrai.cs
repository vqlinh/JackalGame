using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemytrai : MonoBehaviour
{
    public float Speed;
    public float RightPos;
    private Animator EnemyAI;
    // Start is called before the first frame update
    void Start()
    {
        EnemyAI = GetComponent<Animator>();
        Hide();
    }
    void Hide()
    {
        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (transform.localPosition.x < RightPos) // Nếu chưa đi hết bên trái
        {

            transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(RightPos, transform.localPosition.y), Speed * Time.deltaTime);
            EnemyAI.SetBool("Enemytrai", false);

            if (transform.localPosition.x >= RightPos)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
                EnemyAI.SetBool("Enemytrai", true);
            }
        }
    }

}
