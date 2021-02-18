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

    private SpriteRenderer _spriteRenderer;
    private Material _defaultMaterial;
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _deathSound;

    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = Core.Instance.MainAudioSource;
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

    public void Dead()
    {
        if(Random.Range(1, 101) < _dropChance)
        {
            var core = Core.Instance;

            var bonus = Instantiate(_bonusPrefab, transform.position, new Quaternion());
            bonus.WeaponPrefab = core.WeaponPull[Random.Range(0, core.WeaponPull.Count)];
        }
        if(_audioSource != null)
            _audioSource.PlayOneShot(_deathSound);
        _dropChance = 0;
        Destroy(gameObject);
    }

    protected virtual void OnStart() { }
}
