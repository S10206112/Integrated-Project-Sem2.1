using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 1.5f)]
    private float fireRate = 0.1f;

    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private ParticleSystem muzzleParticle;

    [SerializeField]
    private AudioSource gunFireSource;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >=  fireRate)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                timer = 0f;
                FireGun();
            }
        }
    }
    private void FireGun()
    {
        //Debug.DrawRay(transform.position, firePoint.forward * 100, Color.red, 2f);

        muzzleParticle.Play();
        gunFireSource.Play();

        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<SimpleEnemyHealth>();
            if (health != null)
                health.TakeDamage(damage);
        }
    }
}
