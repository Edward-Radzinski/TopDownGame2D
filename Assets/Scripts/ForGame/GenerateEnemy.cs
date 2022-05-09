using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    public GameObject[] Enemy;
    private float _timeSpawn = 5;
    private int _enemyCount = 0;
    [SerializeField] private float _timeRate;
    private void Start()
    {
        _timeRate = PlayerPrefs.GetFloat("timeRevial");
    }
    private void Update()
    {
        _timeSpawn -= Time.deltaTime;
        if (_timeSpawn <= 0)
        {
            _timeSpawn = _timeRate;
            var rand = Random.Range(0, Enemy.Length);
            var randPos = new Vector2(Random.Range(-13, 14), Random.Range(-5, 6));
            Generate(rand, randPos);
        }
    }
    private void Generate(int rand, Vector2 randPos)
    {
        _enemyCount++;
        if (_timeRate >= 1 && _enemyCount >= 5)
        {
            _timeRate -= 0.15f;
            _enemyCount = 0;
        } Instantiate(Enemy[rand], randPos, Quaternion.identity);
    }
}
