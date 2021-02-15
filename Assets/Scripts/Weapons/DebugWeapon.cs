using UnityEngine;

public class DebugWeapon : Weapon
{
    [SerializeField] private GameObject _bullet;

    public override float Shoot(float timeBetweenShots, float angle, Vector2 position)
    {
        Instantiate(_bullet, position, new Quaternion(0, 0, angle, 0));
        return 0;
    }
}
