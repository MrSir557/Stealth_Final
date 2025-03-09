using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaserProjectile : MonoBehaviour
{
    public float lifeTime = 1f;

    public Transform target;
    private Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        direction = target.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (direction * 0.1f);

        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider whatIHit)
    {
        if(whatIHit.tag == "Enemy")
        {
            whatIHit.GetComponent<Enemy>().Stun();
            Destroy(gameObject);
        }
    }
}
