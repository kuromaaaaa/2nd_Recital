using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDirection : MonoBehaviour
{
    [SerializeField] GameObject _mousePosition;
    Playercontroller _pc;
    MousePosition _mp;
    // Start is called before the first frame update
    void Start()
    {
        _pc = GameObject.Find("Player").GetComponent<Playercontroller>();
        _mp = GameObject.Find("MousePosition").GetComponent<MousePosition>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!_mp.Mouse && _pc.Rh == 0 && _pc.Rv == 0)
        {
            
        }
        else
        {
            this.transform.up = _mousePosition.transform.position - transform.position;
        }
    }
}
