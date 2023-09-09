using UnityEngine;

public class BulletLPrefub: BulletBase
{
    GameObject _rotation;
    GameObject _mousePosition;
    SpriteRenderer _child;
    Rigidbody2D _rb;

    [SerializeField] float _bulletSpeed = 10;
    [SerializeField] int _bulletDamage;
    Vector3 _direction;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rotation = GameObject.Find("rotation");
        _mousePosition = GameObject.Find("MousePosition");

        if (_rotation == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _direction = _mousePosition.transform.position - _rotation.transform.position;
        }

        Destroy(this.gameObject,2f);
        _child = transform.Find("player-shoot1").gameObject.GetComponent<SpriteRenderer>();
        _child.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.up = _direction;
        _rb.velocity = _direction.normalized * _bulletSpeed;
        _child.enabled=true;
    }



    public override void BulletHit(Collider2D coll)
    {
        if (coll.gameObject.tag == ("Wall"))
        {
            _direction *= new Vector2(1, -1);
        }
        if (coll.gameObject.tag == ("Enemy"))
        {
            coll.GetComponent<EnemyBase>().Damage(_bulletDamage);
        }
    }
}
