using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("ÉvÉåÉCÉÑÅ[");
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
        {
            Vector3 Rstick = new Vector3(Rh * 4 + _player.transform.position.x, Rv * -4 + _player.transform.position.y, 0);
            this.transform.position = Rstick;
        }
        Debug.Log(Rh);
    }
}
