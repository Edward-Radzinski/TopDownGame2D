using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 100;
    public GameObject[] Bonus;
    public ParticleSystem deathPref;
    private void Update()
    {
        var rand = Random.Range(0, Bonus.Length);
        if (health <= 0)
        {
            Score.score++;
            Generate(rand);
            Instantiate(deathPref, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void GetDamage(int damage)
    {
        health -= damage;
    }
    private void Generate(int rand)
    {
        Instantiate(Bonus[rand], transform.position, Quaternion.identity);
    }
}
