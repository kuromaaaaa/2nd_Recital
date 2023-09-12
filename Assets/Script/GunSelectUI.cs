using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GunSelectUI : MonoBehaviour
{
    GameObject _parent;
    Playercontroller _pc;
    // Start is called before the first frame update
    void Start()
    {
        _parent = GameObject.Find("GunUI");
        _pc = GameObject.Find("Player").GetComponent<Playercontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 3 ; i++)
        {
            _parent.transform.GetChild(i).GetComponent<Image>().color = new Color(0.2196078f, 0.2196078f, 0.2196078f, 1.0f);
        }
        _parent.transform.GetChild(_pc.GunType - 1).GetComponent<Image>().color = new Color(0.0f, 0.5882353f, 0.0f, 1.0f);
    }
}
