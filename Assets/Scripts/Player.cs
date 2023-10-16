using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public float MoveSpeed;
    public Rigidbody2D rb;
    public Vector3 MoveInput;
    public SpriteRenderer CharacterSR;
    public Animator animator;
    //Vector2 movement;


    void Update()
    {
        MoveInput.x = Input.GetAxis("Horizontal");
        MoveInput.y = Input.GetAxis("Vertical");

        //animator.SetFloat("horizontal", movement.x);
        //animator.SetFloat("vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);

        rb.velocity = MoveInput.normalized * MoveSpeed;
        if (MoveInput != Vector3.zero)
        {
            float angle = Mathf.Atan2(MoveInput.y, MoveInput.x) * Mathf.Rad2Deg;
            CharacterSR.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }


    }
    //private void FixedUpdate()
    //{
    //    rb.MovePosition(rb.position+movement*MoveSpeed*Time.fixedDeltaTime);
    //}
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
