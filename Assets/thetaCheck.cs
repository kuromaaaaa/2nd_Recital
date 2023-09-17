using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class thetaCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 0 && transform.position.x > 0)
            Debug.Log(Mathf.Atan(transform.position.y/transform.position.x));
        if (transform.position.x < 0)
            Debug.Log(Mathf.PI + Mathf.Atan(transform.position.y / transform.position.x));
        if (transform.position.y < 0 && transform.position.x > 0)
            Debug.Log(Mathf.PI*2 + Mathf.Atan(transform.position.y / transform.position.x));
    }
}
