using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _start;
    [SerializeField] GameObject _end;
    float _range;
    [SerializeField] float _time;
    float _speed;
    void Start()
    {
        _range = _end.transform.position.x - _start.transform.position.x;
        Debug.Log(_range);
        _speed = _range / _time;
    }

    private void FixedUpdate()
    {
        if(this.transform.position.x <= _end.transform.position.x)
        this.transform.position = new Vector3(this.transform.position.x + _speed/50,this.transform.position.y);
        Debug.Log(_speed);
    }
}
