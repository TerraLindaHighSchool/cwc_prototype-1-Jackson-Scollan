using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject projectilePrefab;
    public PlayerController playerController;
    public DestroyBullet DestroyBullet;
    public int bulletsShot = 0;
    int BulletCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        //Space bar fires bullets
        if (Input.GetKeyDown(KeyCode.Space) && !playerController.gameOver)
        {
            Bullet();
           
        }

        //Max shots is 5
        void Bullet()
            {
            if (bulletsShot <= 10)
            {
                Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
                bulletsShot++;
            }
            else
            {
                StartCoroutine(WaitForBullets());
            }

            

        }

        IEnumerator WaitForBullets()
        {
            yield return new WaitForSeconds(30);
            

        }
        
    }
}
