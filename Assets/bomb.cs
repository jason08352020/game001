using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    Rigidbody rb;
    manager gm;
    public int pointvalue = 5;
    public ParticleSystem p;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * Random.Range(14, 19), ForceMode.Impulse);
        rb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4, 4), -6, 0);
        gm=GameObject.Find("GameManager").GetComponent<manager>();
    }
    void OnMouseDown()
    {
        if (gm.isplay)
        {
            gm.updateScore(pointvalue);
            Instantiate(p, transform.position, p.transform.rotation);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("boom"))
        {
            gm.gameover();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
