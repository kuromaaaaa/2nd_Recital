using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLv3 : EnemyBase
{
    [SerializeField] GameObject _enemyBulletPrefub;
    [SerializeField] float _enemyBulletRate;
    float _enemyBulletTimer;
    Animator _anim;
    bool _shootAnim = false;
    bool _crossAttack = false;
    float _r;
    float _theta;
    [SerializeField] float _moveSpeed;
    float _direction = 1;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        _anim = this.transform.GetChild(0).GetComponent<Animator>();
        _r = Vector2.Distance(this.transform.position, new Vector2(0, 0));
        //0,0を中心にした自身の角度(ラジアン)を求める
        
        if (transform.position.y > 0 && transform.position.x > 0)
            _theta = (Mathf.Atan(transform.position.y / transform.position.x));
        if (transform.position.x < 0)
            _theta = (Mathf.PI + Mathf.Atan(transform.position.y / transform.position.x));
        if (transform.position.y < 0 && transform.position.x > 0)
            _theta = (Mathf.PI * 2 + Mathf.Atan(transform.position.y / transform.position.x));
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        _enemyBulletTimer += Time.deltaTime;
        //弾発射
        if(_enemyBulletTimer > _enemyBulletRate/2)
        {
            _shootAnim = true;
        }
        if (_enemyBulletRate < _enemyBulletTimer)
        {
            GameObject shot = Instantiate(_enemyBulletPrefub) as GameObject;
            shot.transform.position = this.gameObject.transform.position;
            if(_crossAttack)
            {
                shot.transform.eulerAngles = new Vector3(0,0,45);
            }
            _crossAttack = !_crossAttack;

            _enemyBulletTimer = 0;
            _shootAnim = false;
        }
        _anim.SetBool("shootStay", _shootAnim);
        //動かす
        this.transform.position = new Vector2(_r * Mathf.Cos(_theta),_r * Mathf.Sin(_theta));
        _theta += Time.deltaTime * 0.1f * _moveSpeed * _direction;
        Direction();
    }
    void Direction()
    {
        if(transform.position.x > 0)
        {
            if (transform.position.y > 4)
            {
                _direction = -1;
            }
            if (transform.position.y < -2.1)
            {
                _direction = 1;
            }
        }
        else
        {
            if (transform.position.y > 4)
            {
                _direction = 1;
            }
            if (transform.position.y < -2.1)
            {
                _direction = -1;
            }
        }

    }
}
