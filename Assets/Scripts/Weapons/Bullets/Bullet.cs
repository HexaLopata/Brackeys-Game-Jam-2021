using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    public int Damage 
    {
        get => _damage;
        set => _damage = value;
    }

    public float LifeTime
    {
        get => _lifeTime;
        set => _lifeTime = value;
    }

    private SpriteRenderer _sprite;
    private Vector3 _velocity = Vector3.zero;
    private float _livingTime = 0;

    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _lifeTime;
    [SerializeField] private AudioSource _awakeSound;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        if(_awakeSound != null)
            _awakeSound.Play();
    }

    private void FixedUpdate()
    {
        _livingTime += Time.fixedDeltaTime;
        transform.position += _speed * Time.deltaTime * transform.right;
        if(_livingTime >= _lifeTime)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}