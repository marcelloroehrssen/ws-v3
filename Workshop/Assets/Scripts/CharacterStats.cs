using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(ParticleSystem))]
public class CharacterStats : MonoBehaviour
{

    public float maxHealth = 10;
    private float health = 10;

    public RectTransform healthBar;
    public RectTransform healthBarContainer;
    public Animator cameraAnimator;
    public ParticleSystem bloodParticleSystem;

    [HideInInspector]
    public int score = 0;
    public Text scoreText;

    private Animator animator;
    private AudioSource audioSourceDie;
    private AudioSource audioSourceHit;

    public void Start()
    {
        animator = GetComponent<Animator>();
        audioSourceDie = GetComponents<AudioSource>()[0];
        audioSourceHit = GetComponents<AudioSource>()[1];
    }

    public void Buff(float health)
    {
        maxHealth += health;
    }

    public void Damage(float damage)
    {
        health -= damage;
        healthBar.sizeDelta = new Vector2(health / maxHealth * healthBarContainer.sizeDelta.x, healthBarContainer.sizeDelta.y);

        audioSourceHit.Play();
        if (cameraAnimator != null)
        {
            cameraAnimator.SetTrigger("PlayerIsHit");
        }
        animator.SetTrigger("IsHit");

        if (bloodParticleSystem != null)
        {
            bloodParticleSystem.Play();
        }

        if (health <= 0)
        {
            animator.SetTrigger("IsDead");
        }
    }

    public void StartDieing()
    {
        audioSourceDie.Play();
    }

    public void IsDead()
    {
        Destroy(gameObject);
    }

    public void IncrementScore(int scoreDelta)
    {
        score += scoreDelta;
        scoreText.text = score.ToString();
    }
}
