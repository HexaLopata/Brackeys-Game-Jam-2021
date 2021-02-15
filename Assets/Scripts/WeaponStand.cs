using UnityEngine;

public class WeaponStand : MonoBehaviour
{
    [SerializeField] private Weapon _weaponPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Triangle>();
        player.Weapon = _weaponPrefab;
    }
}
