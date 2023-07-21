using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trianglePrefub : MonoBehaviour
{
    GameObject _rotation;
    GameObject _mousePosition;
    Rigidbody2D _rb;

    [SerializeField] float _triangleSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rotation = GameObject.Find("rotation");
        _mousePosition = GameObject.Find("MousePosition");
        this.transform.up = _mousePosition.transform.position - _rotation.transform.position;
        Vector2 direction = _mousePosition.transform.position - _rotation.transform.position;
        _rb.velocity = direction.normalized * _triangleSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
