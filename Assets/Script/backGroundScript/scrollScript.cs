using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollScript : MonoBehaviour
{
    [SerializeField] float _scaleX;
    [SerializeField] float _goScaleX;
    [SerializeField] float _scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x <= _scaleX)
        {
            this.transform.position = new Vector3(_goScaleX,this.transform.position.y);
        }
    }
    public void FixedUpdate()
    {
        this.transform.position = new Vector3(this.transform.position.x - _scrollSpeed/50,this.transform.position.y,this.transform.position.z);
    }
}
