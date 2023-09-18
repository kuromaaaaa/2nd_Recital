using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLv2 : EnemyBase
{
    GameObject _player;
    [SerializeField] float _enemyBulletRate;
    float _enemyBulletTimer;
    [SerializeField] GameObject _enemyBulletPrefub;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        _player = GameObject.Find("Player");
        if (_player)
        {
            if (_player.transform.position.x > this.gameObject.transform.position.x)
            {
                this.gameObject.transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                this.gameObject.transform.localScale = new Vector2(1, 1);
            }
        }
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        _enemyBulletTimer += Time.deltaTime;
        if(_enemyBulletRate < _enemyBulletTimer)
        {
            Instantiate(_enemyBulletPrefub).transform.position = this.gameObject.transform.position;
            _enemyBulletTimer = 0;
        }
    }
}
