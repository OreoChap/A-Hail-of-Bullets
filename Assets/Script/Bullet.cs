using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;
    public float lifeTime = 2f;

    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * transform.forward * Time.deltaTime;
        if (startTime + lifeTime < Time.time) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other){
        if (CompareTag(other.tag)) {
            return;
        }
        Destroy(gameObject);
    }
}
