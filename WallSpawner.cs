using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject wallprefab;

    [SerializeField]
    private float _maxTime = 5.0f;

    [SerializeField]
    private float _heightRange = 3.45f;

    private float _timer;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (_timer > _maxTime)
        {
            SpawnWall();
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }

    private void SpawnWall()
    {
        Vector3 spawnPos =
            transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        Instantiate(wallprefab, spawnPos, Quaternion.identity);
    }
}
