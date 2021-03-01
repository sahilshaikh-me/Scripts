using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SoundTest : MonoBehaviour
{
    public static SoundTest Instance { get; set; }
    public int num;
  public  float fireRate ;
    public GameObject ShotGun,Rifle,revolver,HuntingRifle,ShotGunBtn;
    public Toggle ShotGunT, RifleT, revolverT, HuntingRifleT;
    public float nextFire   = 0.0f;

    private float Riflerate ;
    public AudioSource audio;
    private Camera MainCamera ;

    public GameObject WeaponPanel;
    public bool WeaponPanelIsActive;

    public GameObject BulletHole;

    private void Start()
    {
        MainCamera = Camera.main;
    }

    public void WPanel()
    {
        WeaponPanelIsActive = !WeaponPanelIsActive;
    }
    public void Update()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        if(WeaponPanelIsActive == true)
        {
            WeaponPanel.SetActive(true);
        }
        if(WeaponPanelIsActive == false)
        {   
            WeaponPanel.SetActive(false);
        }
        if (FireBtn.Instance.isPress == true && IsOkToShoot()) {

            Shoot();
        }
        if (ShotGunT.isOn)
        {
           
            ShotGun.SetActive(true);
            ShotGunBtn.SetActive(true);
            Rifle.SetActive(false);
            revolver.SetActive(false);
            HuntingRifle.SetActive(false);
        }
        if (RifleT.isOn)
        {
          
            fireRate = 0.14f;
            ShotGun.SetActive(false);
            Rifle.SetActive(true);
            revolver.SetActive(false);
            HuntingRifle.SetActive(false);
            ShotGunBtn.SetActive(false);
        }
        if (revolverT.isOn)
        {
           
            ShotGun.SetActive(false);
            Rifle.SetActive(false);
            revolver.SetActive(true);
            HuntingRifle.SetActive(false);
            ShotGunBtn.SetActive(false);

        }
        if (HuntingRifleT.isOn)
        {

            ShotGun.SetActive(false);
            Rifle.SetActive(false);
            revolver.SetActive(false);
            HuntingRifle.SetActive(true);
            ShotGunBtn.SetActive(false);
        }

    }

    public bool IsOkToShoot()  {
     
    
     
      bool itsOk = false;
     if (Time.time>nextFire) {
         nextFire = Time.time + fireRate;
         itsOk = true;
     }
     return itsOk;
 }
 
 public void Shoot()
{

    audio.Play(); 
        num++;
        RaycastHit hit;
        if (Physics.Raycast(MainCamera.transform.position,MainCamera.transform.forward,out hit))
        {
            Instantiate(BulletHole, hit.point +new Vector3(0,0,-.1f), Quaternion.FromToRotation(Vector3.up, hit.normal));
            Debug.Log(hit.transform.gameObject.name);
            hit.transform.GetComponent<Health>().LifeLeft -= 10;
            if(hit .transform.GetComponent<Health>().LifeLeft <= 0)
            {
               hit.transform.GetComponent<Ragdoll>().DoRagdoll(false);

                hit.transform.GetComponent<Zombie>().enabled = false;
            }

        }

}
}
