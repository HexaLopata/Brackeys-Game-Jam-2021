using UnityEngine;

public class TimeLimitedEnemy : Enemy
{
    [Header("Life time in seconds")]
    [SerializeField] private float _lifeTime;

    private float _currentLifeTime = 0f;

    protected override void Step(float delta)
    {
        _currentLifeTime += delta;
        if(_currentLifeTime >= _lifeTime)
            Destroy(gameObject);
    }
}
