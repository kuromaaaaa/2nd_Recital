
using UnityEngine;

public class BulletGPrefub : BulletBase
{
    GameObject _rotation;
    GameObject _mousePosition;
    Rigidbody2D _rb;

    [SerializeField] float _bulletSpeed = 10;
    [SerializeField] int _bulletDamage;
    [SerializeField] float _bulletLife = 3f;
    [SerializeField] GameObject _hitEffect;
    Vector2 _direction;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rotation = GameObject.Find("rotation");
        _mousePosition = GameObject.Find("MousePosition");

        float rx = new System.Random().Next(-10,10) * 0.1f;
        float ry = new System.Random().Next(-10,10) * 0.1f;
        Vector3 ran = new Vector3(rx, ry,0);
        if (_rotation == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _direction = _mousePosition.transform.position - _rotation.transform.position + ran;
        }

        Destroy(this.gameObject, _bulletLife);

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.up = _direction;
        _rb.velocity = _direction.normalized * _bulletSpeed;
        
    }

    public override void BulletHit(Collider2D coll)
    {
        if (coll.gameObject.tag == ("Wall"))
        {
            Destroy(this.gameObject);
        }
        if (coll.gameObject.tag == ("Enemy"))
        {
            coll.GetComponent<EnemyBase>().Damage(_bulletDamage);
            Instantiate(_hitEffect).gameObject.transform.position = this.transform.GetChild(0).transform.position;
            Destroy(this.gameObject);
        }
    }
}
