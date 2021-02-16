using UnityEngine;

public class EnemyType2 : Enemy
{
    [SerializeField] private float _speed;

    private Triangle _target;

    protected override void OnStart()
    {
        _target = FindObjectOfType<Triangle>();
    }

    protected override void Step(float delta)
    {
        if(_target != null)
        {
            var distance = _target.transform.position - transform.position;
            transform.position += distance.normalized * _speed * delta;
        }
    }
}
