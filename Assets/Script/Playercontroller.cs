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
    systemLoadScene _sls;
    ParticleSystem _ps;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _jumpPower = 10;
    bool _jumpReady = true;
    float _jumpTimer= 0;
    float _groundGravity;
    [SerializeField] int _playerLife = 3;
    [SerializeField] GameObject _muzzle;
    public int PlayerLife { get { return _playerLife; } }
    //���˂����e�̃v���n�u
    [SerializeField] GameObject _bulletPrefubL;
    [SerializeField] GameObject _bulletPrefubG;
    [SerializeField] GameObject _bulletPrefubS1;
    [SerializeField] GameObject _bulletPrefubS2;
    [SerializeField] GameObject _bulletPrefubS3;
    float _BSPower;
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
    //�_���[�W�Ɩ��G����
    [SerializeField] GameObject _damagePrefub;
    [SerializeField] float _mutekiTime = 2;
    float _mutekiCount;
    bool _muteki = false;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sls = GameObject.Find("--system--").GetComponent<systemLoadScene>();
        _ps = GetComponent<ParticleSystem>();
        _ps.Stop();
        if (GetComponent<Animator>())
        {
            _anim = GetComponent<Animator>();
        }
        _groundGravity = _rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(_muteki)
        {
            Muteki();//���G����
        }
        float h = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(h * _moveSpeed, _rb.velocity.y);

        if((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Ltrigger") > 0) && _jumpReady == true )
        {
            _rb.AddForce(Vector2.up * _jumpPower ,ForceMode2D.Impulse);
            _groundGravity = _rb.gravityScale;
            _rb.gravityScale = 0;

            _jumpReady = false;
        }
        if((!Input.GetButton("Jump") && Input.GetAxis("Ltrigger") == 0) || _jumpTimer > 0.3 || _jumpReady == true)
        {
            _rb.gravityScale = _groundGravity;
            _jumpTimer = 0;
        }
        if(_jumpReady == false)
        {
            _jumpTimer += Time.deltaTime;
        }

        //�e����
        if(Input.GetButton("Fire1") || Input.GetAxisRaw("Rtrigger") > 0 && _rh+_rv != 0)
        {
            if(_sls.GameClear ==false)
            FireUp();
        }
        //�`���[�W�V���b�g����
        if(_gunType == 3 && Input.GetButtonUp("Fire1"))
        {
            if (_BSPower < 10)
            {
                GameObject shot = Instantiate(_bulletPrefubS1) as GameObject;
                shot.transform.position = _muzzle.transform.position;
                shot.GetComponent<BulletSPrefub>().BulletDamage((int)_BSPower);

            }
            else if (_BSPower < 20)
            {
                GameObject shot = Instantiate(_bulletPrefubS2) as GameObject;
                shot.transform.position = _muzzle.transform.position;
                shot.GetComponent<BulletSPrefub>().BulletDamage((int)_BSPower);
            }
            else
            {
                if(_BSPower >100)
                {
                    _BSPower = 100;
                }
                GameObject shot = Instantiate(_bulletPrefubS3) as GameObject;
                shot.transform.position = _muzzle.transform.position;
                shot.GetComponent<BulletSPrefub>().BulletDamage((int)_BSPower);
            }
            _ps.Stop();
            _BSPower = 0;
        }
        //R�X�e�B�b�N�̓���
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
        if (GetComponent<Animator>())
        {
            _anim.SetBool("IsGround", _jumpReady);
        }

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
                if(_BSPower == 0)
                    {
                        _ps.Play();
                    }
                if(_rateTimer >= _rateS)
                    {
                        //�`���[�W�V���b�g����
                        _BSPower += Time.deltaTime*20;
                    }
                break;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Enemy") && !_muteki)
        {
            Debug.Log("�G�ɓ����������̏�����`��(collosion)");
            _playerLife -= 1;
            _muteki = true;
        }
        if(collision.gameObject.tag == ("Wall"))
        {
            _jumpReady = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("EnemyBullet") && !_muteki)
        {
            Debug.Log("�G�ɓ����������̏�����`���e");
            _playerLife -= 1;
            _muteki = true;
            if(_damagePrefub)
            {
                Instantiate(_damagePrefub).transform.position = this.transform.position;
            }
        }
    }
    void Muteki()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.6f);
        this.gameObject.transform.GetChild(0).transform.GetChild(0).
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.6f);
        //���G����
        _mutekiCount += Time.deltaTime;
        if(_mutekiCount > _mutekiTime)
        {
            _muteki = false;
            _mutekiCount = 0;
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }
}

