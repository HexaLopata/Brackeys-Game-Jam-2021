using UnityEngine;

public class Triangle : MonoBehaviour
{
    public Weapon Weapon
    {
        get => _weapon;
        set => _weapon = value;
    } 

    private Vector2 _velocity = Vector2.zero;

    [SerializeField] private float _speed = 30f; 
    [SerializeField] private bool _inverted = false;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _distanceBetweenBulletAndTriangle = 0.25f;
    [SerializeField] private ParticleSystem _deathEffect;

    private float _timeBetweenShots = 0f;
    [Header("Sound Settings")]
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] int _soundLayer;
    [SerializeField] int _maxSoundsCountOnLayer;

    private void Update()
    {
        var delta = Time.deltaTime;
        _timeBetweenShots += delta;
        Vector3 inputVector = new Vector3(0, 0, 0);
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        transform.position += (inputVector * delta * _speed);

        var angle = FindAngleBetweenCursor();
        if(_inverted)
            angle = angle + 180;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);

        bool condition;
        if(_weapon.AutoAttack)
            condition = Input.GetMouseButton(0);
        else
            condition = Input.GetMouseButtonDown(0);
        if(condition)
        {
            if(_weapon != null)
            {
                _timeBetweenShots = _weapon.Shoot(_timeBetweenShots, angle, transform.position +
                                                                     transform.up.normalized * _distanceBetweenBulletAndTriangle);
            }
        
        }
    }

    private float FindAngleBetweenCursor()
    {
        var camera = Camera.main;
        var mousePos2D = Input.mousePosition;
        var screenToCameraDistance = camera.nearClipPlane;

        var mousePosNearClipPlane = new Vector3(mousePos2D.x, mousePos2D.y, screenToCameraDistance);

        var worldPointPos = camera.ScreenToWorldPoint(mousePosNearClipPlane);

        var angle = Vector2.SignedAngle(Vector2.right, worldPointPos - transform.position);
        return angle;
    }

    public void Kill()
    {
        Instantiate(_deathEffect, transform.position, new Quaternion());
        Core.Instance.AudioSystem.TryPlaySound(_deathSound, _soundLayer, _maxSoundsCountOnLayer);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        TriangleManager.Instance.RemoveTriangle(this);
    }
}