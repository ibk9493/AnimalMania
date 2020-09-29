using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColourCollect : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI Alphabet;
    public float IncreaseHealth = 0.2f;
    GameObject Healthbar;
    void Start()
    {
        Healthbar = GameObject.FindGameObjectWithTag("Canvasget");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
          
            Alphabet.gameObject.SetActive(true);
            Healthbar.transform.GetChild(1).GetComponent<Image>().fillAmount += IncreaseHealth;
          
            Destroy(this.gameObject);
        }
    }
}
