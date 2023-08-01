using UnityEngine;

public class BulletLPrefub: MonoBehaviour
{
    GameObject _rotation;
    GameObject _mousePosition;
    GameObject _player;
    Rigidbody2D _rb;

    [SerializeField] float _triangleSpeed = 10;
    Vector2 _direction;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rotation = GameObject.Find("rotation");
        _mousePosition = GameObject.Find("MousePosition");
        _player = GameObject.Find("ÉvÉåÉCÉÑÅ[");

        
        _direction = _mousePosition.transform.position - _rotation.transform.position;

        Destroy(this.gameObject,2f);

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.up = _direction;
        _rb.velocity = _direction.normalized * _triangleSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("Wall"))
        {
            _direction *= new Vector2(1, -1);
        }
    }
}
