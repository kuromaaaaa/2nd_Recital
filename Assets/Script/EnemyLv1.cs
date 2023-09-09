using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLv1 : EnemyBase
{
    GameObject _player;
    Rigidbody2D _rb;
    Vector2 _moveDirection;
    [SerializeField] float _moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        _moveDirection = _player.transform.position - this.transform.position;
        _rb.velocity = _moveDirection.normalized * _moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Player"))
        {
            this.GetComponent<EnemyBase>().Damage(1);
        }
    }
}
