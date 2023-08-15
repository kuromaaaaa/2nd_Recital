using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLv3 : EnemyBase
{
    [SerializeField] GameObject _enemyBulletPrefub;
    [SerializeField] float _enemyBulletRate;
    float _enemyBulletTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        _enemyBulletTimer += Time.deltaTime;
        if (_enemyBulletRate < _enemyBulletTimer)
        {
            Instantiate(_enemyBulletPrefub).transform.position = this.gameObject.transform.position;
            _enemyBulletTimer = 0;
        }
    }
}
