using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    
    [SerializeField]
    private float timer = 5;
    private float bulletTime;
    
    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float enemySpeed;
    private void Start() 
    {
        
    }

    private void Update() 
    {
        enemy.SetDestination(player.position);
        shootplayer();    
    }

    void shootplayer()
    {
        bulletTime -= Time.deltaTime;

        if(bulletTime > 0)
        {
            return;
        }

        bulletTime = timer;

        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletrig = bulletObj.GetComponent<Rigidbody>();
        bulletrig.AddForce(bulletrig.transform.forward * enemySpeed);
        Destroy(bulletObj,5f);

    }

}
