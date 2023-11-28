using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY : MonoBehaviour
{
    public int Health = 100;
    
    

    public virtual void onDeath()
    {
        gameObject.SetActive(false);
        
        Debug.Log("Enemy Died died");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
