using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Transform target;
    public float bulletSpeed = 65f;
    public GameObject impactEffect;
    private bool flag = false;

    public void Seek (Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 direction = target.position - transform.position;
        float distanceAtFrame = bulletSpeed * Time.deltaTime;
        if(!flag)
        {
            transform.Translate(direction.normalized * distanceAtFrame, Space.World);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            flag = true;  
            Destroy(gameObject);
            GameObject effectInstance = (GameObject)Instantiate(impactEffect,transform.position, transform.rotation);
            Destroy(effectInstance, 2f);

        }
    }
}
