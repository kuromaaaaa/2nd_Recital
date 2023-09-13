using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollChild : scrollScript
{
    systemLoadScene _sls;
    // Start is called before the first frame update
    void Start()
    {
        _sls = GameObject.Find("--system--").GetComponent<systemLoadScene>();
    }

    new void FixedUpdate()
    {
        if (_sls.GameClear == false)
        {
            base.FixedUpdate();
        }
    }
}
