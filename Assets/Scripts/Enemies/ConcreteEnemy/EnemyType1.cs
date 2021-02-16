using UnityEngine;

public class EnemyType1 : TimeLimitedEnemy
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed;

    protected override void Step(float delta)
    {
        base.Step(delta);
        transform.position += (_speed * _direction.normalized * delta);
    }
}
