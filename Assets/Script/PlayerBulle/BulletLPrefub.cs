using UnityEngine;

public class BulletLPrefub: BulletBase
{
    GameObject _rotation;
    GameObject _mousePosition;
    Rigidbody2D _rb;

    [SerializeField] GameObject _hitEffect;
    [SerializeField] float _bulletSpeed = 10;
    [SerializeField] int _bulletDamage;
    [SerializeField] float _bulletLife = 3f;
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

        Destroy(this.gameObject,_bulletLife);
        this.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.up = _direction;
        _rb.velocity = _direction.normalized * _bulletSpeed;
        this.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
    }



    public override void BulletHit(Collider2D coll)
    {
        if (coll.gameObject.tag == ("Wall"))
        {
            Debug.Log("HitGround");
            _direction *= new Vector2(1, -1);
        }
        if (coll.gameObject.tag == ("MainCamera"))
        {
            Debug.Log("hitWall");
            _direction *= new Vector2(-1, 1);
        }
        if (coll.gameObject.tag == ("Enemy"))
        {
            coll.GetComponent<EnemyBase>().Damage(_bulletDamage);
            Instantiate(_hitEffect).gameObject.transform.position = this.transform.GetChild(0).transform.position;
            Destroy(this.gameObject);
        }
    }
}
