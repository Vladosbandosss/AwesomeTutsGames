using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsters;
    private GameObject _spawnedMonster;

    [SerializeField] private Transform leftPos, rightPos;

    private int _randomIndex,_randomSide;

    [SerializeField] private float minTimeToSpawnMonster = 1f, maxTimeToSpawnMonster = 5f;
    [SerializeField] private float minMonsterSpeed = 2f, maxMonsterSpeed = 6f;

    private void Start()
    {
        StartCoroutine(nameof(SpawnMonster));
    }

    private IEnumerator SpawnMonster()
    {
        yield return new WaitForSeconds(Random.Range(minTimeToSpawnMonster, maxTimeToSpawnMonster));

        _randomIndex = Random.Range(0, monsters.Length);
        _randomSide = Random.Range(0, 2);

        _spawnedMonster = Instantiate(monsters[_randomIndex]);

        if (_randomSide==0)
        {
            _spawnedMonster.transform.position = leftPos.position;
            _spawnedMonster.GetComponent<MonsterController>().moveSpeed =
                Random.Range(minMonsterSpeed, maxMonsterSpeed);
        }
        else
        {
            _spawnedMonster.transform.position = rightPos.position;
            _spawnedMonster.GetComponent<MonsterController>().moveSpeed =
                Random.Range(-minMonsterSpeed, -maxMonsterSpeed);
            _spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        
        StartCoroutine(nameof(SpawnMonster));
    }
}
