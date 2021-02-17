using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Wave data
/// </summary>
[CreateAssetMenu(fileName = "Wave", menuName = "Wave Settings", order = 51)]
public class Wave : ScriptableObject
{
    [Header("Top spawner settings")]
    public float delayBetweenSpawnTOP;
    public float randomTimeRangeTOP;
    public List<Enemy> enemyPullTOP;
    [Header("Bottom spawner settings")]
    public float delayBetweenSpawnBOTTOM;
    public float randomTimeRangeBOTTOM;
    public List<Enemy> enemyPullBOTTOM;
    [Header("Left spawner settings")]
    public float delayBetweenSpawnLEFT;
    public float randomTimeRangeLEFT;
    public List<Enemy> enemyPullLEFT;
    [Header("Right spawner settings")]
    public float delayBetweenSpawnRIGHT;
    public float randomTimeRangeRIGHT;
    public List<Enemy> enemyPullRIGHT;
    [Space]
    public float timeInSeconds;
}
