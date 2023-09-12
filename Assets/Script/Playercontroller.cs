using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playercontroller : MonoBehaviour
{
    Rigidbody2D _rb;
    Animator _anim;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _jumpPower = 10;
    [SerializeField] int _playerLife = 3;
    bool _jumpReady = true;
    [SerializeField] GameObject _muzzle;
    public int PlayerLife { get { return _playerLife; } }
    //���˂����e�̃v���n�u
    [SerializeField] GameObject _bulletPrefubL;
    [SerializeField] GameObject _bulletPrefubG;
    [SerializeField] GameObject _bulletPrefubS;
    [SerializeField] int _gunType = 1;
    public int GunType { get { return _gunType; } }

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
        if (GetComponent<Animator>())
        {
            _anim = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float _h = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(_h * _moveSpeed, _rb.velocity.y);
        //_rb.velocity = new Vector2(_rb.velocity.x +3, _rb.velocity.y);

        if((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Ltrigger") > 0) && _jumpReady == true )
        {
            _rb.AddForce(Vector2.up * _jumpPower ,ForceMode2D.Impulse);
            _jumpReady = false;
        }
        if(Input.GetButton("Fire1") || Input.GetAxisRaw("Rtrigger") > 0 && _rh+_rv != 0)
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
        if (_gunType == 0)
        {
            _gunType = 3;
        }
        else if(_gunType == 4)
        {
            _gunType = 1;
        }
        //�R���g���[���[�e�̎����ւ�
        if (0 < Input.GetAxisRaw("crossX"))
        {
            _gunType = 3;
        }
        else if(Input.GetAxisRaw("crossX") < 0)
        {
            _gunType = 1;
        }
        if(0 < Input.GetAxisRaw("crossY"))
        {
            _gunType = 2;
        }

        //�W�����v�A�j���[�V�����p�ϐ�
        if(GetComponent<Animator>())
        _anim.SetFloat("SpeedY", _rb.velocity.y);

    }
    //�e�����������̏���
    private void FireUp()
    {
        switch(_gunType)
        {
            case 1:
            {
                if(_rateTimer >= _rateL)
                {
                    Instantiate(_bulletPrefubL).transform.position = _muzzle.transform.position;
                    _rateTimer = 0; 
                }
                break;
            }
            case 2: 
            {
                if (_rateTimer >= _rateG)
                {
                    Instantiate(_bulletPrefubG).transform.position = _muzzle.transform.position;
                    _rateTimer = 0;
                }
                break;
            }
            case 3:
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
            _playerLife -= 1;
        }
        if(collision.gameObject.tag == ("Wall"))
        {
            _jumpReady = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("EnemyBullet"))
        {
            Debug.Log("�G�ɓ����������̏�����`���e");
            _playerLife -= 1;
            if(_damagePrefub)
            {
                Instantiate(_damagePrefub).transform.position = this.transform.position;
            }
        }
    }
}

