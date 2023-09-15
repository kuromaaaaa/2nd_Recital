using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletSPrefub : BulletBase
{
    int _bulletDamage;
    Rigidbody2D _rb;
    GameObject _rotation;
    GameObject _mousePosition;
    [SerializeField] float _bulletSpeed;
    [SerializeField] GameObject _hitEffect;
    Vector2 _direction;
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
        Destroy(this.gameObject, 3f);
        this.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.up = _direction;
        _rb.velocity = _direction.normalized * _bulletSpeed;
        this.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
    }

    public void BulletDamage(int n)
    {
        _bulletDamage = n;
        Debug.Log(_bulletDamage);
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
        if(coll.gameObject.tag == ("EnemyBullet") && _bulletDamage > 10)
        {
            Destroy(coll.gameObject);
        }
    }
}
