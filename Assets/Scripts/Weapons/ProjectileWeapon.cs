using UnityEngine;

public class ProjectileWeapon : Weapon
{
    public override int SynergyIndex => _synergyIndex;

    public override int SynergyLevel 
    {
        get => _synergyLevel;
        set => _synergyLevel = value;
    }

    public override bool AutoAttack
    {
        get => _autoAttack;
        set => _autoAttack = value;
    }

    [SerializeField] private Bullet _bullet;
    [Header("One shot per Fire Rate seconds")]
    [SerializeField] private float _fireRate;
    [Space]
    [Header("Angle range in degrees")]
    [SerializeField] private float _angleRange;
    [Header("Bullets per one shot")]
    [SerializeField] private int _bulletCount = 1;
    [Space]
    [SerializeField] private bool _autoAttack = true;
    [Header("Increasing of the stats")]
    [SerializeField] private float _fireRatePerLevel;
    [SerializeField] private float _angleRangePerLevel;
    [SerializeField] private float _bulletCountPerLevel;
    [SerializeField] private float _damagePerLevel;
    [SerializeField] private float _bulletLifeTimePerLevel;
    [SerializeField] private float _bulletScalePerlevel;
    [Header("(Synergy works with weapons having same indexes)")]
    [Header("Weapon synergy index")]
    [SerializeField] private int _synergyIndex;

    [Header("Sound Settings")]
    [SerializeField] private AudioClip _awakeSound;
    [SerializeField] int _soundLayer;
    [SerializeField] int _maxSoundsCountOnLayer;

    private int _synergyLevel = 0;

    private void PlayAwakeSound()
    {
        if(_awakeSound != null)
        {
            Core.Instance.AudioSystem.TryPlaySound(_awakeSound, _soundLayer, _maxSoundsCountOnLayer);
        }
    }

    public override float Shoot(float timeBetweenShots, float angle, Vector2 position)
    {
        var additionalFireRate = _synergyLevel * _fireRatePerLevel;
        var additionalBulletCount = (int)(_synergyLevel * _bulletCountPerLevel);
        var additionalAngle = _synergyLevel * _angleRangePerLevel;
        var additionDamage = _synergyLevel * _damagePerLevel;
        var additionalLifeTime = _synergyLevel * _bulletLifeTimePerLevel;
        var additionalScale = _synergyLevel * _bulletScalePerlevel;
        Bullet bullet;
        if(timeBetweenShots >= _fireRate + additionalFireRate)
        {
            PlayAwakeSound();
            for(int i = 0; i < _bulletCount + additionalBulletCount; i++)
            {
                bullet = Instantiate(_bullet, position, new Quaternion());
                bullet.Damage += (int)additionDamage;
                bullet.LifeTime += additionalLifeTime;
                bullet.transform.localScale += new Vector3(additionalScale, additionalScale, 0);
                bullet.transform.rotation = Quaternion.Euler(0, 0,
                                            angle + Random.Range(-(_angleRange + additionalAngle), _angleRange + additionalAngle));
            }

            return 0;
        }
        else
            return timeBetweenShots;
    }
}
