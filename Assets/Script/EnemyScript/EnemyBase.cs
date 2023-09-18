using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] float _life;
    [SerializeField] GameObject _deathPrefub;
    GameObject _playerGameObject;
    [SerializeField] bool _Flip = true;
    // Start is called before the first frame update
    public void Start()
    {
        _playerGameObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    public void Update()
    {
        if (_playerGameObject && _Flip)
        {
            if (_playerGameObject.transform.position.x > this.gameObject.transform.position.x)
            {
                this.gameObject.transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                this.gameObject.transform.localScale = new Vector2(1, 1);
            }
        }
        //‘Ì—Í‚ª0‚ÌƒvƒŒƒnƒu‚ğ¢Š«‚µ‚Ä€‚Ê
        if(_life <= 0)
        {
            if (_deathPrefub)
            {
                Instantiate(_deathPrefub).transform.position = this.transform.position;
            }
            Destroy(this.gameObject);
        }
    }

    public void Damage(int n)
    {
        _life -= n;
    }
}
