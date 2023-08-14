using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] float _life;
    [SerializeField] GameObject _deathPrefub;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        //�̗͂�0�̎��v���n�u���������Ď���
        if(_life <= 0)
        {
            if (_deathPrefub)
            {
                Instantiate(_deathPrefub).transform.position = this.transform.position;
            }
            Destroy(this.gameObject);
        }
        Debug.Log(_life);
    }

    public void Damage(int n)
    {
        _life -= n;
    }
}
