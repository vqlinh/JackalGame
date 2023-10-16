using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Transform FireposX;
    public GameObject rocket;

    public float TimeFire = 0.2f;

    private float timeFire;
    public float GrenadeForce;
    public SpriteRenderer CharacterSR;

    void Start()
    {
        Hide();
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
        GameObject RocketTMP = Instantiate(rocket, FireposX.position, Quaternion.identity);
        Rigidbody2D rb = RocketTMP.GetComponent<Rigidbody2D>();
        rb.AddForce(CharacterSR.transform.up * GrenadeForce, ForceMode2D.Impulse);
    }

}
