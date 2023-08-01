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
    [SerializeField] GameObject _bulletPrefubL;
    [SerializeField] GameObject _bulletPrefubG;

    [SerializeField] GunType _gunType = GunType.Laser;
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
            Debug.Log("a");
        }
        if(Input.GetButton("Fire1"))
        {
            FireUp();
        }
        float Rh = Input.GetAxisRaw("RstickHori");
        float Rv = Input.GetAxisRaw("RstickVert");
        if (Rh != 0 || Rv != 0)
        {
            FireUp();
        }

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

    }



    private void FireUp()
    {
        switch(_gunType)
        {
            case GunType.Laser:
                {
                    Instantiate(_bulletPrefubL).transform.position = _muzzle.transform.position;
                    break;
                }
            case GunType.Gatling: 
                {
                    Instantiate(_bulletPrefubG).transform.position = _muzzle.transform.position;
                    break;
                }
            case GunType.Sniper:
                {
                    break;
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
