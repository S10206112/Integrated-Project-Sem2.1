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
        //setting the conditions for timing between shots
        timer += Time.deltaTime;
        if (timer >=  fireRate)
        {
            //shoots
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

        //play the shot particle and the shot audio
        muzzleParticle.Play();
        gunFireSource.Play();

        //creates a raycast
        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitInfo;

        //if raycast hits an object
        if(Physics.Raycast(ray, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<SimpleEnemyHealth>();
            //if it hits an enemy basically since only enemies have health
            if (health != null)
                //damage the enemy
                health.TakeDamage(damage);
        }
    }
}
