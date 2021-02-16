using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _delayBetweenSpawn;
    [SerializeField] private float _randomTimeRange = 0f;
    [Space]
    [SerializeField] private List<Enemy> _enemyList = new List<Enemy>();

    private float _currentDelay =  0f;
    private float _currentRandomTime = 0f;

    private void Start()
    {
        _currentRandomTime = Random.Range(-_randomTimeRange, _randomTimeRange);
    }

    private void Update()
    {
        _currentDelay += Time.deltaTime;
        if( (_currentDelay >= _delayBetweenSpawn + _currentRandomTime) && _enemyList.Count > 0)
        {
            Instantiate(_enemyList[Random.Range(0, _enemyList.Count)],
                         transform.position,
                         new Quaternion());

            _currentDelay = 0;
            _currentRandomTime = Random.Range(-_randomTimeRange, _randomTimeRange);
        }
    }
}