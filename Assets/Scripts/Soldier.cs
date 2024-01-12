using UnityEngine;

public class Soldier : MonoBehaviour
{
    public float Speed;
    public float DownPos;
    public bool MovingBot;
    private Animator Nhalinh;
    public Rocket Rocket;
    public GunX Gunx;
    // Start is called before the first frame update
    void Start()
    {
        Nhalinh = GetComponent<Animator>();
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
            Rocket.Show();
            Gunx.Hide();
        }
    }

    void Update()
    {
        if (transform.localPosition.y > DownPos) // Nếu chưa đi hết xuống dưới
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, DownPos), Speed * Time.deltaTime);
            Nhalinh.SetBool("Soldierhand", false);
            if (transform.localPosition.y <= DownPos)
            {
                MovingBot = true;
                Nhalinh.SetBool("Soldierhand", true);
            }
        }
    }
}

