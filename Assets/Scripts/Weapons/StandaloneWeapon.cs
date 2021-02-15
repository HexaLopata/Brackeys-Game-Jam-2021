using UnityEngine;

public class StandaloneWeapon : Weapon
{
    [SerializeField] private Bullet _bullet;
    [Header("One shot per Fire Rate seconds")]
    [SerializeField] private float _fireRate;
    [Space]
    [Header("Angle range in degrees")]
    [SerializeField] private float _angleRange;

    public override float Shoot(float timeBetweenShots, float angle, Vector2 position)
    {
        Bullet bullet;
        if(timeBetweenShots >= _fireRate)
        {
            bullet = Instantiate(_bullet, position, new Quaternion(0, 0, angle, 0));
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle + Random.Range(-_angleRange, _angleRange));

            return 0;
        }
        else
            return timeBetweenShots;
    }
}
