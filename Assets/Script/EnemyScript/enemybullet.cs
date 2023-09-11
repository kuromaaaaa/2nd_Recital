using UnityEngine;

public class enemybullet : MonoBehaviour
{
    GameObject _player;
    Vector2 _direction;
    Rigidbody2D _rb;
    [SerializeField] float _bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _direction = _player.transform.position - this.gameObject.transform.position;
        _rb = this.GetComponent<Rigidbody2D>();
        _rb.velocity = _direction.normalized * _bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
