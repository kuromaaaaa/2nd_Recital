using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _moveSpeed;
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
        _rb.velocity = new Vector2(_rb.velocity.x +3, _rb.velocity.y);

        if(Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(Vector2.up * 10 ,ForceMode2D.Impulse);
            Debug.Log("a");
        }
    }
}
