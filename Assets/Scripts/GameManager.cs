using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip bullet;
    public AudioClip bulletAttack;
    public AudioClip destroyTank;
    public AudioClip destroyEnemy;
    public AudioClip grenade;
    public AudioClip grenadeExplosion;

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void AudioBullet()
    {
        audioSource.PlayOneShot(bullet);
    }
    public void AudioBulletAttack()
    {
        audioSource.PlayOneShot(bulletAttack);
    }
 
    public void AudioDestroyTank()
    {
        audioSource.PlayOneShot(destroyTank);
    }
    public void AudioDestroyEnemy()
    {
        audioSource.PlayOneShot(destroyEnemy);
    }
    public void AudioGrenade()
    {
        audioSource.PlayOneShot(grenade);
    }
    public void AudioGrenadeExplosion()
    {
        audioSource.PlayOneShot(grenadeExplosion);
    }

    void Update()
    {
        CheckBossesRemaining();
    }

    void CheckBossesRemaining()
    {
        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");

        if (bosses.Length == 0)
        {
            Invoke("Win", 2f);
        }
    }
    void Win() {

        SceneManager.LoadScene("WinGame");
    }
}
