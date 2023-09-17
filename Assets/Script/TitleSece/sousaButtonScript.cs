using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sousaButtonScript : MonoBehaviour
{
    int _sousa = 0;
    float _interval;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Submit"))
        {
            GetComponent<AudioSource>().Play();
        }
        _interval += Time.deltaTime;
        if(_sousa == 1 &&(Input.GetButtonDown("Submit") || Input.GetButtonDown("Fire1")) && _interval > 0.1)
        {
            this.transform.GetChild(2).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(false);
            _interval = 0;
            _sousa = 2;
        }
        if (_sousa == 2 && (Input.GetButtonDown("Submit") || Input.GetButtonDown("Fire1")) && _interval > 0.1)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(2).gameObject.SetActive(false);
            _sousa = 0;
            _interval = 0;
        }
    }
    public void sousa()
    {
        _sousa = 1;
        this.transform.GetChild(1).gameObject.SetActive(true);
        this.transform.GetChild(0).gameObject.SetActive(false);
        _interval = 0;
    }
}
