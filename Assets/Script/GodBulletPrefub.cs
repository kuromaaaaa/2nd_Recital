using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodBulletPrefub : MonoBehaviour
{
    GameObject _parent;
    Vector2 _direction;
    [SerializeField] float _speed;
    // Start is called before the first frame update
    void Start()
    {
        _parent = transform.parent.gameObject;
        _direction = this.gameObject.transform.position - _parent.transform.position;
        this.transform.up = _direction;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = _direction.normalized * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
