using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _moveSpeed;
    [SerializeField] GameObject _muzzle;
    //���˂����e�̃v���n�u
    [SerializeField] GameObject _bulletPrefubL;
    [SerializeField] GameObject _bulletPrefubG;
    [SerializeField] GameObject _bulletPrefubS;
    [SerializeField] GunType _gunType = GunType.Laser;
    //�e�̃��[�g�p�^�C�}�[
    float _rateTimer = 0;
    [SerializeField] float _rateL;
    [SerializeField] float _rateG;
    [SerializeField] float _rateS;
    //�R���g���[���[R�X�e�B�b�N�̒l
    float _rh = 0;
    float _rv = 0;
    public float Rh { get { return _rh; } }
    public float Rv { get { return _rv; } }

    [SerializeField] GameObject _damagePrefub;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float _h = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(_h * _moveSpeed, _rb.velocity.y);
        //_rb.velocity = new Vector2(_rb.velocity.x +3, _rb.velocity.y);

        if(Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(Vector2.up * 10 ,ForceMode2D.Impulse);
        }
        if(Input.GetButton("Fire1") || Input.GetAxisRaw("Rtrigger") > 0 && _rh*_rv != 0)
        {
            FireUp();
        }
        _rh = Input.GetAxisRaw("RstickHori");
        _rv = Input.GetAxisRaw("RstickVert");
        //�e�A�˗p�^�C�}�[
        _rateTimer += Time.deltaTime;

        //�}�E�X�e�����ւ�
        float wh = Input.GetAxis("Mouse ScrollWheel");
        if(wh < 0)
        {
            _gunType += 1;
        }
        else if (wh > 0)
        { 
            _gunType -= 1;
        }
        if (_gunType == GunType.goThree)
        {
            _gunType = GunType.Sniper;
        }
        else if(_gunType == GunType.goOne)
        {
            _gunType = GunType.Laser;
        }
        //�R���g���[���[�e�̎����ւ�
        
    }
    //�e�����������̏���
    private void FireUp()
    {
        switch(_gunType)
        {
            case GunType.Laser:
            {
                if(_rateTimer >= _rateL)
                {
                    Instantiate(_bulletPrefubL).transform.position = _muzzle.transform.position;
                    _rateTimer = 0; 
                }
                break;
            }
            case GunType.Gatling: 
            {
                if (_rateTimer >= _rateG)
                {
                    Instantiate(_bulletPrefubG).transform.position = _muzzle.transform.position;
                    _rateTimer = 0;
                }
                break;
            }
            case GunType.Sniper:
            {
                if(_rateTimer >= _rateS)
                    {
                        _rateTimer = 0;
                    }
                break;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Enemy"))
        {
            Debug.Log("�G�ɓ����������̏�����`��(collosion)");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("EnemyBullet"))
        {
            Debug.Log("�G�ɓ����������̏�����`���e");
            if(_damagePrefub)
            {
                Instantiate(_damagePrefub).transform.position = this.transform.position;
            }
        }
    }
}

enum GunType
{
    goThree = 0,
    Laser = 1,
    Gatling = 2,
    Sniper = 3,
    goOne = 4,
}
