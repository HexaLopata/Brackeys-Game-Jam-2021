using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] int _healthPoints = 100;
    [Header("Chance on droping weapon")]
    [SerializeField] int _dropChance;
    [SerializeField] private WeaponStand _bonusPrefab;
    [Space]
    [SerializeField] private float _damageAnimationDuration = 0.2f;
    [SerializeField] private Material _damageMaterial;
    [SerializeField] private ParticleSystem _deathEffect;

    [Header("Sound Settings")]
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] int _soundLayer;
    [SerializeField] int _maxSoundsCountOnLayer;

    private SpriteRenderer _spriteRenderer;
    private Material _defaultMaterial;

    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultMaterial = _spriteRenderer.material;
        OnStart();
    } 

    public void Update()
    {
        Step(Time.deltaTime);
    }

    protected abstract void Step(float delta);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Triangle>().Kill();
            _dropChance = 0;
            Dead();
        }
    }

    public virtual void TakeDamage(int amount)
    {
        _healthPoints -= amount;
        if(_healthPoints <= 0)
            Dead();    
        StartCoroutine(DamageAnimation());    
    }

    private IEnumerator DamageAnimation()
    {
        _spriteRenderer.material = _damageMaterial;
        yield return new WaitForSeconds(_damageAnimationDuration);
        _spriteRenderer.material = _defaultMaterial;
    } 

    public virtual void Dead()
    {
        Instantiate(_deathEffect, transform.position, new Quaternion());
        if(Random.Range(1, 101) < _dropChance)
        {
            var core = Core.Instance;

            var bonus = Instantiate(_bonusPrefab, transform.position, new Quaternion());
            bonus.WeaponPrefab = core.WeaponPull[Random.Range(0, core.WeaponPull.Count)];
        }
        Core.Instance.AudioSystem.TryPlaySound(_deathSound, _soundLayer, _maxSoundsCountOnLayer);
        _dropChance = 0;
        Destroy(gameObject);
    }

    protected virtual void OnStart() { }
}
