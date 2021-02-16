using UnityEngine;

public class WeaponStand : MonoBehaviour
{
    public Weapon WeaponPrefab
    {
        get => _weaponPrefab;
        set => _weaponPrefab = value;
    }

    [SerializeField] private Weapon _weaponPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            var player = other.gameObject.GetComponent<Triangle>();
            player.Weapon = _weaponPrefab;
            Destroy(gameObject);
        }
    }
}
