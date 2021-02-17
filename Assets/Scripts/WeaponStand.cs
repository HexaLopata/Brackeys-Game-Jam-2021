using UnityEngine;

public class WeaponStand : MonoBehaviour
{
    public Weapon WeaponPrefab
    {
        get => _weaponPrefab;
        set => _weaponPrefab = value;
    }

    [SerializeField] private Weapon _weaponPrefab;
    [SerializeField] private float _lifeTime = 7f;

    private float _currentLifeTime = 0;

    private void Update()
    {
        _currentLifeTime += Time.deltaTime;
        if(_currentLifeTime >= _lifeTime)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            TriangleManager.Instance.AddNewTriangle(_weaponPrefab);
            Destroy(gameObject);
        }
    }
}
