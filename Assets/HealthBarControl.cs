using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarControl : MonoBehaviour
{
    public Image Healthbar;
    public Image PlayerHealthBar;
    public float decreaseSpeed = 0.1f;
    public GameObject Gameovercanvas;
    [Header("Direction Light Elements")]
    public Light DirectionLightObject;
    [SerializeField] [Range(0f, 10f)] float lerptime;
    [SerializeField] Color[] mycolours;

    int colourindex = 0;
    int len;
    float fillAmountvalue;


    // Start is called before the first frame update
    void Start()
    {
       // Healthbar = GameObject.FindGameObjectWithTag("Canvasget").gameObject.GetComponent<Image>();
        //Directional light
        len = mycolours.Length;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Healthbar.fillAmount >= 0)
        {
            Healthbar.fillAmount -= decreaseSpeed * Time.deltaTime;
            fillAmountvalue = Healthbar.fillAmount;
            
        }
        colourChanger();
        if (PlayerHealthBar.fillAmount <= 0.01f)
        {
            GameOverScreen();
        }
    }
   
    void colourChanger()
    {
        DirectionLightObject.color = Color.Lerp(DirectionLightObject.color, mycolours[colourindex],lerptime*Time.deltaTime);


        if (fillAmountvalue > 0.9f)
        {
            colourindex=0 ;
        }
        else if (fillAmountvalue > 0.8f)
         {
            colourindex = 1;
        }
        else if (fillAmountvalue > 0.7f)
        {
            colourindex = 2;
        }
        else if (fillAmountvalue > 0.6f)
        {
            colourindex = 3;
        }
        else if (fillAmountvalue > 0.5f)
        {
            colourindex = 4;
        }
        else if (fillAmountvalue > 0.4f)
        {
            colourindex = 5;
        }
        else if (fillAmountvalue > 0.3f)
        {
            colourindex = 6;
        }
        else if (fillAmountvalue > 0.2)
        {
            colourindex = 7;
        }
        else if (fillAmountvalue > 0.1)
        {
            colourindex = 8;
        }
        else if (fillAmountvalue <= 0.03)
        {
            GameOverScreen();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "NavmeshIgnore")
        {
            GameOverScreen();
        }
    }

    void GameOverScreen()
    {
        Time.timeScale = 0;
        Gameovercanvas.SetActive(true);
    }
}
