using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    GameObject _player;
    GameObject _crossSprite;
    Playercontroller _pc;
    bool _mouseOn;
    public bool Mouse { get { return _mouseOn; } }
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _crossSprite = transform.GetChild(0).gameObject;
        _pc = _player.GetComponent<Playercontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            _mouseOn = true;
        }
        if(_pc.Rh != 0 || _pc.Rv != 0)
        {
            _mouseOn = false;
        }

        if (_mouseOn)
        {
            Vector3 mousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosi.z = 0;
            this.transform.position = mousePosi;
        }
        else 
        {
            Vector3 Rstick = new Vector3(_pc.Rh * 4 + _player.transform.position.x, _pc.Rv * -4 + _player.transform.position.y, 0);
            this.transform.position = Rstick;
        }

        if (!_mouseOn && _pc.Rh == 0 && _pc.Rv == 0)
        {
            _crossSprite.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            _crossSprite.GetComponent <SpriteRenderer>().enabled = true;
        }
    }
}
