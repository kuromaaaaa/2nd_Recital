using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Rh = Input.GetAxisRaw("RstickHori");
        float Rv = Input.GetAxisRaw("RstickVert");
        if (Rh == 0 && Rv == 0)
        {
            Vector3 mousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosi.z = 0;
            this.transform.position = mousePosi;
        }
        else 
        { }
    }
}
