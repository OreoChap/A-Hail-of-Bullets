using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject prefabBullet;

    public float pistolFireCD = 0.2f;
    public float shotGunFireCD = 0.5f;
    public float rifleFireCD = 0.1f;

    float lastFireTime;

    public int curGun {get; private set;}

    public void Fire(bool keyDown, bool keyPressed) {
        Debug.Log("~~Fire~~");
        switch(curGun) {
            case 0:
                if(keyDown) {
                    PistolFire();
                }
                break;
            case 1:
                if(keyDown) {
                    ShotGunFire();
                }
                break;
            case 2:
                 if(keyPressed) {
                    RifleFire();
                }
                break;
        }
    }

    public int Change() {
        curGun += 1;
        if(curGun == 3) {
            curGun = 0;
        }
        return curGun;
    }

    public void PistolFire() {
        if(lastFireTime + pistolFireCD > Time.time){
            return;
        }
        lastFireTime = Time.time;
        GameObject bullet = Instantiate(prefabBullet, null);
        bullet.transform.position = transform.position + transform.forward * 1.0f;
        bullet.transform.forward = transform.forward;
    }

    public void RifleFire() {
         if(lastFireTime + rifleFireCD > Time.time){
            return;
        }
        lastFireTime = Time.time;
        GameObject bullet = Instantiate(prefabBullet, null);
        bullet.transform.position = transform.position + transform.forward * 1.0f;
        bullet.transform.forward = transform.forward;
    }

    public void ShotGunFire() {
         if(lastFireTime + shotGunFireCD > Time.time){
            return;
        }
        lastFireTime = Time.time;

        for (int i = -2; i <= 2 ; i++) {
            GameObject bullet = Instantiate(prefabBullet, null);
            Vector3 dir = Quaternion.Euler(0, i * 10, 0) * transform.forward;

            bullet.transform.position = transform.position + dir * 1.0f;
            bullet.transform.forward = dir;

            Bullet b = bullet.GetComponent<Bullet>();
            b.lifeTime = 0.3f;
        }
    }
}
