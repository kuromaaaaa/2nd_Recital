using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDirection : MonoBehaviour
{
    [SerializeField] GameObject _mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.up = _mousePosition.transform.position - transform.position;
    }
}
