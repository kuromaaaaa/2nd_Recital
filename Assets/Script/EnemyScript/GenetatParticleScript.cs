using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenetatParticleScript : MonoBehaviour
{
    [SerializeField] GameObject _generatObject;
    float _timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > 1)
        {
            Instantiate(_generatObject).transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
        
    }
}
