using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject prefabBoomEffect;
    public float speed = 2;
    public float fireTime = 0.1f;
    public float maxHp = 1;
    Vector3 input;
    Transform player;
    float hp;
    bool dead = false;
    Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        weapon = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    void Move() {
        input = player.position - transform.position;
        input = input.normalized;
        transform.position += input * speed * Time.deltaTime;

        if (input.magnitude > 0.1f) {
            transform.forward = input;
        }
    }

    void Fire() {
        weapon.Fire(true, true);
           }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("PlayerBullet")) {
            Destroy(other.gameObject);
            hp--;
            if(hp <= 0) { 
                dead = true;
                Debug.Log("==== Enemy dead! ====");
                Destroy(gameObject);
            }
        }
    }
}
