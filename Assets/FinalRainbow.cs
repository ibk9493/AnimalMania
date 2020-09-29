using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRainbow : MonoBehaviour
{
    public GameObject R;
    public GameObject O;
    public GameObject Y;
    public GameObject G;
    public GameObject B;
    public GameObject I;
    public GameObject V;
    public GameObject RainBowFinal;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        CheckObjects();
        
    }


    void CheckObjects()
    {
        if(R.activeInHierarchy && O.activeInHierarchy && Y.activeInHierarchy 
            && G.activeInHierarchy && I.activeInHierarchy && B.activeInHierarchy
            && V.activeInHierarchy)
        {
            RainBowFinal.SetActive(true);
        }
        
    }
}
