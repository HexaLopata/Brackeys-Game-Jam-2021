using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType4 : Enemy
{

    [SerializeField] private float _speed;
    [SerializeField] private float _dashDelay;
    [SerializeField] private float _dashTime;

    private float _currentDashDelay = 0;
    private float _currentDashTime = 0;
    private Triangle _target;

    protected override void OnStart()
    {
        _target = FindObjectOfType<Triangle>();
    }

    protected override void Step(float delta)
    {
        if (_target != null)
        {
            _currentDashDelay += delta;
            if (_currentDashDelay >= _dashDelay)
            {
                _currentDashTime += delta;
                var distance = _target.transform.position - transform.position;
                transform.position += distance.normalized * _speed * delta;
                if(_currentDashTime >= _dashTime)
                {
                    _currentDashTime = 0;
                    _currentDashDelay = 0;
                }
            }
        }
        else
            _target = FindObjectOfType<Triangle>();
    }
    
}
