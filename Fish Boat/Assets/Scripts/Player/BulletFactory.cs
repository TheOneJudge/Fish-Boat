using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletFactory : MonoBehaviour
{
    //Player01 bullet stuff
public GameObject Bullet01;
public Transform bulletSpawn01;
public int poolsize01 = 5;
private List<GameObject> objectPool01;

// Start is called before the first frame update
public void onShootPlayer01(InputAction.CallbackContext context)
{
    if(context.started)
    {
        Shoot01();
    }
}

void Start()
{
    objectPool01 = new List<GameObject>();

    for(int i = 0; i < poolsize01; i++)
    {
        GameObject obj = Instantiate(Bullet01);
        obj.SetActive(false);
        objectPool01.Add(obj);

    }
}

// Update is called once per frame
void Update()
{
    
}

public GameObject GetBullet01()
{
    for(int i = 0; i < objectPool01.Count; i++)
    {
        if(!objectPool01[i].activeInHierarchy)
        {
            objectPool01[i].SetActive(true);
            return objectPool01[i];
        }
    }

    return null;
}

void Shoot01()
{
    GameObject bullet = GetBullet01();
    if(bullet != null)
    {
        bullet.transform.position = bulletSpawn01.position;
        bullet.transform.rotation = bulletSpawn01.rotation;
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        bulletRB.velocity = bullet.transform.forward * 30f;

        StartCoroutine(ReturnBulletToPool(bullet));
    }
    
}

IEnumerator ReturnBulletToPool(GameObject bullet)
{
    yield return new WaitForSeconds(3);

    if(bullet != null)
    {
        bullet.SetActive(false);
    }
}
}
