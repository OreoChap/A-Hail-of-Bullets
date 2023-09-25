using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 移动速度
    public float speed = 3;
    // 最大血量
    public float maxHp = 20;
    // 变量 输入方向用
    Vector3 input;
    Weapon weapon;
    // 是否死亡
    bool dead = false;
    // 当前血量
    float hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        weapon = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));
        // Debug.Log(input);
        bool fireKeyDown = Input.GetKeyDown(KeyCode.J);
        bool fireKeyPressed = Input.GetKey(KeyCode.J);
        bool changeKeyDown = Input.GetKeyDown(KeyCode.Q);
        if (!dead) { 
            Move();
            weapon.Fire(fireKeyDown,fireKeyPressed);
            if (changeKeyDown) {
                ChangeWeapon();
            }
        }
    }

    private void ChangeWeapon() {
        int w = weapon.Change();
    }

    void Move() {
        input = input.normalized;
        transform.position += input * speed * Time.deltaTime;
        if (input.magnitude > 0.1f) {
            transform.forward = input;
        }

        Vector3 temp = transform.position;
        const float BORDER = 10f;
        if (temp.z > BORDER) { temp.z = BORDER;}
        if (temp.z < -BORDER) { temp.z = -BORDER;}
        if (temp.x > BORDER) { temp.x = BORDER;}
        if (temp.x < -BORDER) { temp.x = -BORDER;}
        transform.position = temp;
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("EnemyBullet")) {
            if (hp <= 0) {return;}
            hp--;
            if(hp <=0) { dead = true;
            
            Debug.Log("==== Player dead! ====");
            }
        }
    }
}
