using UnityEngine;

public class nhalinhno : MonoBehaviour
{
    private Animator nhalinh;
    private BoxCollider2D bc;
    public Soldier soldier;


    void Start()
    {
        bc = (BoxCollider2D)GetComponent<Collider2D>();
        nhalinh = GetComponent<Animator>();
        nhalinh.SetBool("nhalinhno", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grenade")
        {
            nhalinh.SetBool("nhalinhno", true);
            bc.enabled = false;
            soldier.Show();

        }
    }
}

