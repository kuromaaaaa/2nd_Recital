using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class EnemyBulletLv3 : MonoBehaviour
{
    GameObject _parent;
    Vector2 _direction;
    [SerializeField] float _speed;
    // Start is called before the first frame update
    void Start()
    {
        _parent = transform.parent.gameObject;
        _direction = this.gameObject.transform.position - _parent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = _direction.normalized * _speed;
    }
}
