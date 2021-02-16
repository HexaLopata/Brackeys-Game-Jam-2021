using UnityEngine;

public class ProjectileWeapon : Weapon
{
    [SerializeField] private Bullet _bullet;
    [Header("One shot per Fire Rate seconds")]
    [SerializeField] private float _fireRate;
    [Space]
    [Header("Angle range in degrees")]
    [SerializeField] private float _angleRange;
    [Header("Bullets per one shot")]
    [SerializeField] private int _bulletCount = 1;

    public override float Shoot(float timeBetweenShots, float angle, Vector2 position)
    {
        Bullet bullet;
        if(timeBetweenShots >= _fireRate)
        {
            for(int i = 0; i < _bulletCount; i++)
            {
                bullet = Instantiate(_bullet, position, new Quaternion());
                bullet.transform.rotation = Quaternion.Euler(0, 0, angle + Random.Range(-_angleRange, _angleRange));
            }

            return 0;
        }
        else
            return timeBetweenShots;
    }
}
