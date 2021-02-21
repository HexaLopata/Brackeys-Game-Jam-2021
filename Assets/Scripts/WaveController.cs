using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;


public class WaveController : MonoBehaviour
{
    public UnityEvent onWaveChanged;
    public int WaveNumber => _waveNumber;

    [SerializeField] private List<Spawner> _top;
    [SerializeField] private List<Spawner> _bottom;
    [SerializeField] private List<Spawner> _left;
    [SerializeField] private List<Spawner> _right;
    [Space]
    [SerializeField] private List<Wave> _waves;

    [SerializeField] private int _waveNumber = 1;

    private float _timeOnCurrentWave = 0;
    private Wave _currentWave;

    private void Start()
    {
        _currentWave = _waves[_waveNumber - 1];
        SetWave(_waveNumber);
    }

    private void Update()
    {
        _timeOnCurrentWave += Time.deltaTime;

        if(_timeOnCurrentWave >= _currentWave.timeInSeconds)
        {
            SetWave(++_waveNumber);
            _timeOnCurrentWave = 0;
        }
    }

    private void SetWave(int waveNumber)
    {
        if(_waves.Count > waveNumber - 1)
        {
            _currentWave = _waves[waveNumber - 1];
            foreach(var spawner in _top)
            {
                spawner.DelayBetweenSpawn = _currentWave.delayBetweenSpawnTOP;
                spawner.RandomTimeRange = _currentWave.randomTimeRangeTOP;
                spawner.EnemyList = _currentWave.enemyPullTOP;
                spawner.CurrentTimeDelay = 0;
            }

            foreach(var spawner in _bottom)
            {
                spawner.DelayBetweenSpawn = _currentWave.delayBetweenSpawnBOTTOM;
                spawner.RandomTimeRange = _currentWave.randomTimeRangeBOTTOM;
                spawner.EnemyList = _currentWave.enemyPullBOTTOM;
                spawner.CurrentTimeDelay = 0;
            }

            foreach(var spawner in _left)
            {
                spawner.DelayBetweenSpawn = _currentWave.delayBetweenSpawnLEFT;
                spawner.RandomTimeRange = _currentWave.randomTimeRangeLEFT;
                spawner.EnemyList = _currentWave.enemyPullLEFT;
                spawner.CurrentTimeDelay = 0;
            }

            foreach(var spawner in _right)
            {
                spawner.DelayBetweenSpawn = _currentWave.delayBetweenSpawnRIGHT;
                spawner.RandomTimeRange = _currentWave.randomTimeRangeRIGHT;
                spawner.EnemyList = _currentWave.enemyPullRIGHT;
                spawner.CurrentTimeDelay = 0;
            }

            onWaveChanged.Invoke();
        }
    }  
}
