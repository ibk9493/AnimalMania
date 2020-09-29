using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;

public class PoliceGun : MonoBehaviour
{  
    public ParticleSystem ImpactEffect;
    GameObject Player;
    [Header("Ray Elements")]
    public float DistanceSight = 10;
    public float DistanceArea = -10;
    public float RayHeight = 1.3f;

    [Header("Player Health Elements")]
    public Image playerhealth;
    public float DamageAmount = 2;
    bool damagetaken = false;
    float StartNavmeshSpeed;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StartNavmeshSpeed = this.gameObject.GetComponent<NavMeshAgent>().speed;
        ImpactEffect.Stop();
    }
    void Update()
    {
        //distance from enemy
        float dist = Vector3.Distance(Player.transform.position, transform.position);

        if (dist <= 5)
        {
            this.gameObject.GetComponent<NavMeshAgent>().speed = 0;
            this.gameObject.transform.LookAt(Player.transform);
        }
        else
            this.gameObject.GetComponent<NavMeshAgent>().speed = StartNavmeshSpeed;


        RaycastShow();

        if(damagetaken)
        {
            playerhealth.fillAmount = playerhealth.fillAmount - DamageAmount * Time.deltaTime;
            shoot();
        }
        else
            StartCoroutine(stopeffect());


    }
    void RaycastShow()
    {

        Vector3 rayPosition = new Vector3(transform.position.x, transform.position.y + RayHeight, transform.position.z);
        Vector3 leftRayRotation = Quaternion.AngleAxis(-DistanceArea, transform.up) * transform.forward;
        Vector3 rightRayRotation = Quaternion.AngleAxis(DistanceArea, transform.up) * transform.forward;


        Ray rayCenter = new Ray(rayPosition, transform.forward);
        Ray rayLeft = new Ray(rayPosition, leftRayRotation);
        Ray rayRight = new Ray(rayPosition, rightRayRotation);

        RaycastHit hit;
        if ((Physics.Raycast(rayCenter, out hit, DistanceSight)) || (Physics.Raycast(rayLeft, out hit, DistanceSight)) || (Physics.Raycast(rayRight, out hit, DistanceSight)))
        {
            if (hit.collider.tag == "Player")
            {
                damagetaken = true;
                print("touching object name=" + hit.collider.tag);
            }
          
        }
        else
            damagetaken = false;

        Debug.DrawRay(Vector3.up * RayHeight + transform.position, transform.forward * DistanceSight, Color.red);
        Debug.DrawRay(Vector3.up * RayHeight + transform.position, rightRayRotation * DistanceSight, Color.white);
        Debug.DrawRay(Vector3.up * RayHeight + transform.position, leftRayRotation * DistanceSight, Color.white);


        if (Input.GetButtonDown("Fire1"))
        {
          // shoot();
        }
    }

    void shoot()
    {
        ImpactEffect.Play();
      //  StartCoroutine(stopeffect());



    }
    IEnumerator stopeffect()
    {
        yield return new WaitForSeconds(1f);
        ImpactEffect.Stop();
    }

}
