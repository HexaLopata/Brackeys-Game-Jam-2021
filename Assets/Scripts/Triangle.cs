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
    [SerializeField] private Weapon _weapon;

    private float _timeBetweenShots = 0f;

    void Update()
    {
        var delta = Time.deltaTime;
        _timeBetweenShots += delta;
        Vector3 inputVector = new Vector3(0, 0, 0);
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        transform.position += (inputVector * delta * _speed);

        var angle = FindAngleBetweenCursor();
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if(Input.GetMouseButton(0))
        {
            if(_weapon != null)
            {
                _timeBetweenShots = _weapon.Shoot(_timeBetweenShots, angle, transform.position);
            }
        }
    }

    private float FindAngleBetweenCursor()
    {
        var camera = Camera.main;;
        var mousePos2D = Input.mousePosition;
        var screenToCameraDistance = camera.nearClipPlane;

        var mousePosNearClipPlane = new Vector3(mousePos2D.x, mousePos2D.y, screenToCameraDistance);

        var worldPointPos = camera.ScreenToWorldPoint(mousePosNearClipPlane);

        var angle = Vector2.SignedAngle(Vector2.right, worldPointPos - transform.position);
        return angle;
    }
}