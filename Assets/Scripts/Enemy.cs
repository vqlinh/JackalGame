using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public float RightPos;
    public float LeftPos;
    public bool MovingBot;
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
        if (collision.gameObject.CompareTag("Bullet"))
        {
            this.gameObject.SetActive(false);
        }
    }


    // Update is called once per frame

    void Update()
    {

        if (transform.localPosition.x > LeftPos) // Nếu chưa đi hết bên trái
        {

            transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(LeftPos, transform.localPosition.y), Speed * Time.deltaTime);
                EnemyAI.SetBool("RightHand", false);

            if (transform.localPosition.x <= LeftPos)
            {

                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
                MovingBot = true;
                EnemyAI.SetBool("RightHand", true);


            }
            else {

            }
        }
    }
 
}
