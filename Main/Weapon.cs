using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static Weapon Wea { get; set; }
    public bool ShootUiButton = false;
    public bool zombieisDeath = false;

    private Camera Cam;
    private bool isReloading;
    private Animator anim;
    public ParticleSystem MuzzelFlash;
    public AudioClip shootSound;
    private AudioSource _AudioSource;

    public float damage = 60;
    public GameObject hitPaticle;
    public GameObject bulletImpact;
    public float range = 10000f;
    public int bulletPerMag = 30;
    public int bulletLeft = 200;
    public int currentBullet;
    public Transform ShootPoint;
    public float fireRate = 0.1f;
    public RaycastHit hit;
    float fireTimer;
    public LayerMask layer;
    void Start()
    {
        Cam = Camera.main;
        _AudioSource = GetComponent<AudioSource>();

        currentBullet = bulletPerMag;
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Wea == null)
        {
            Wea = this;

        }


        if (Input.GetButton("Fire1"))
        {
            if (currentBullet > 0)
            {
                Fire();
            }
            else if (bulletLeft > 0)
            {
                DoReload();
            }
        }


        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }




    }

    private void FixedUpdate()
    {
        if (ShootUiButton)
        {
            if (currentBullet > 0)
            {
                Fire();
            }
            else if (bulletLeft > 0)
            {
                DoReload();
            }
        }
        else
        {
            ShootUiButton = false;
        }


        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

        isReloading = info.IsName("Reload");
        if (info.IsName("Fire"))
        {
            anim.SetBool("Fire", false);
        }



    }

    public void Fire()
    {
        if (fireTimer < fireRate || currentBullet <= 0 || isReloading) return;

        fireTimer = 0.0f;//reset fire

        RaycastHit hit;
        //ShootPoint.transform.forward
        if (Physics.Raycast(Camera.main.transform.position,Cam.transform.forward , out hit))
        {
            Debug.Log(hit.transform.name + "found");
           if(hit.transform.gameObject.tag == "Zombie")
            {
              
                GameObject hitParticleffect = Instantiate(hitPaticle, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                Destroy(hitParticleffect, 0.5f);
            }
            if (hit.transform.gameObject.tag == "Ground" || hit.transform.gameObject.tag == "Walls")
            {
                GameObject bulletHole = Instantiate(bulletImpact, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                Destroy(bulletHole, 0.5f);
            }

            //  GameObject bulletHole = Instantiate(bulletImpact, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            //  Destroy(bulletHole, 0.5f);

            if (hit.transform.GetComponent<Health>())
            {

                hit.transform.GetComponent<Health>().ApplyHealth(50);
                hit.transform.GetComponent<RagDoll>().ActiveRagdoll();
                hit.transform.GetComponent<EnemyAi>().enabled = false;
                zombieisDeath = true;
                Destroy(hit.transform.GetComponent<Health>(), 5);
            }
            if (hit.transform.GetComponent<HealthSniper>())
            {

                hit.transform.GetComponent<HealthSniper>().ApplyHealthSniper(damage);

            }
        }
        anim.CrossFadeInFixedTime("Fire", 0.01f);
        MuzzelFlash.Play();
        anim.SetBool("Fire", true);
        currentBullet--;

        PlayShootSound();

    }

    public void Reload()
    {
        if (bulletLeft <= 0) return;

        int bulletToLoad = bulletPerMag - currentBullet;
        int bulletToDeduct = (bulletLeft >= bulletToLoad) ? bulletToLoad : bulletLeft;

        bulletLeft -= bulletToDeduct;
        currentBullet += bulletToDeduct;


    }

    public void DoReload()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        if (isReloading) return;
        anim.CrossFadeInFixedTime("Reload", 0.01f);
    }

    private void PlayShootSound()
    {

        _AudioSource.PlayOneShot(shootSound);

    }


    public void BtnReloadMenual()
    {
        if (currentBullet < bulletPerMag && bulletLeft > 0)
            DoReload();

    }
}
