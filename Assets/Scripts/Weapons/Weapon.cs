using UnityEngine;
public abstract class Weapon : MonoBehaviour
{
    // Returns new time between shots
    public abstract float Shoot(float timeBetweenShots, float angle, Vector2 position);
}