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
    void Start()
    {
        _player = GameObject.Find("Player");
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
