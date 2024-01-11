using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip bullet;
    public AudioClip bulletAttack;
    public AudioClip bg;
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
        AudioBackground();
    }

    public void AudioBullet()
    {
        audioSource.PlayOneShot(bullet);
    }
    public void AudioBulletAttack()
    {
        audioSource.PlayOneShot(bulletAttack);
    }
    public void AudioBackground()
    {
        audioSource.PlayOneShot(bg);
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
}
