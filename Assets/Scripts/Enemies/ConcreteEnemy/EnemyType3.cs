using UnityEngine;

public class EnemyType3 : Enemy
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _fireDistance;
    [SerializeField] private float _fireTime = 2f;
    private bool _fireState;
    private float _currentFireTime = 0;

    private Triangle _target;

    protected override void OnStart()
    {
        _target = FindObjectOfType<Triangle>();
    }

    protected override void Step(float delta)
    {
        if(_target != null)
        {
            if(_fireState)
            {
                _currentFireTime += delta;
                if(_currentFireTime >= _fireTime)
                {
                    _currentFireTime = 0;
                    var bullet = Instantiate(_bullet, transform.position, new Quaternion());
                    var angle = Vector2.SignedAngle(Vector2.right, transform.position - _target.transform.position);
                    bullet.transform.rotation = Quaternion.Euler(0, 0, 180 + angle);
                    _fireState = false;
                }
            }
            else
            {
                var distance = _target.transform.position - transform.position;
                if(distance.magnitude <= _fireDistance)
                    _fireState = true;
                transform.position += distance.normalized * _speed * delta;
            }
        }
        else
            _target = FindObjectOfType<Triangle>();
    }
}
