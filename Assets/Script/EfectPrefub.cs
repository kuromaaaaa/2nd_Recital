using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectPrefub : MonoBehaviour
{
    [SerializeField] float _destroyTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,_destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
