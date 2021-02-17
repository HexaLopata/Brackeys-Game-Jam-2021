using UnityEngine;
public abstract class Weapon : MonoBehaviour
{
    // Returns new time between shots
    public abstract float Shoot(float timeBetweenShots, float angle, Vector2 position);

    // Synergy works with weapons having same indexes
    public abstract int SynergyIndex { get; }

    public abstract int SynergyLevel { get; set; }

    public abstract bool AutoAttack { get; set; }
}