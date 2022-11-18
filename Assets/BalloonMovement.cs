using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{

    [SerializeField] Rigidbody2D rigid;
    [SerializeField] Vector2 force;



    // Start is called before the first frame update
    void Start()
    {

        rigid = GetComponent<Rigidbody2D>();
   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        force = new Vector2(Random.Range(-18,18), Random.Range(6,7));

        rigid.AddForce(force);
    }
}
