using UnityEngine;

public class GunX : MonoBehaviour
{
    public Transform FireposX;
    public GameObject Grenade;
    public float TimeFire = 0.2f;
    private float timeFire;
    public float GrenadeForce;
    public SpriteRenderer CharacterSR;

    void Start()
    {
        Show();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        timeFire -= Time.deltaTime;
        if (Input.GetKey((KeyCode)'x') && timeFire < 0)
        {
            FireGrenade();
        }
    }

    void FireGrenade()
    {
        timeFire = TimeFire;
        GameObject GrenadeTMP = Instantiate(Grenade, FireposX.position, Quaternion.identity);
        Rigidbody2D rb = GrenadeTMP.GetComponent<Rigidbody2D>();
        rb.AddForce(CharacterSR.transform.up * GrenadeForce, ForceMode2D.Impulse);
        GameManager.instance.AudioGrenade();
    }
}

