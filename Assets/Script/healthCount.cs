using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthCount : MonoBehaviour
{
    Playercontroller _pc;
    Image[] _images;
    [SerializeField] GameObject _parent;
    // Start is called before the first frame update
    void Start()
    {
        _pc = GameObject.Find("Player").GetComponent<Playercontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(_pc.PlayerLife).gameObject.SetActive(false);
    }
}
