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
    // Start is called before the first frame update
    void Start()
    {
        _anim = this.transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        _enemyBulletTimer += Time.deltaTime;
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
    }
}
