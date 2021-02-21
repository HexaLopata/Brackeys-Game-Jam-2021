using UnityEngine;

public class EnemyType5 : Enemy
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private int _bulletCount;
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
        _target = FindObjectOfType<Triangle>();
    }

    public override void Dead()
    {
        for(int i = 0; i < _bulletCount; i++)
        {
            var bullet = Instantiate(_bullet, transform.position, new Quaternion());
            bullet.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        }
        base.Dead();
    }
}
