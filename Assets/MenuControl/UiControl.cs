using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Menubar;
    public GameObject StartMenu;
   
    public string NextLevelName;
    public Sprite[] SlideImages;
    bool startmenurunning=false;
    int len;
    int i=0;

    private void Start()
    {
        Time.timeScale = 1;
        len = SlideImages.Length;
       Invoke("StartMenufunc",3);

    }

    void StartMenufunc()
    {
        Time.timeScale = 0;
        StartMenu.SetActive(true);

        StartMenu.GetComponent<Image>().sprite = SlideImages[i];
        startmenurunning = true;

    }
   public void Gamestart()
    {
        Time.timeScale = 1;
        StartMenu.SetActive(false);
        startmenurunning = false;

    }


    public void NextImage()
    {
        i++;
        if (i < len)
            StartMenu.GetComponent<Image>().sprite = SlideImages[i];
        else
            i--;

    }
    public void PrevImage()
    {
        i--;
        if (i < 0)
            i++;
        else
           StartMenu.GetComponent<Image>().sprite = SlideImages[i];

    }

    void Update()
    {

       if( Input.GetKeyDown(KeyCode.Escape) && !startmenurunning){
            if (Menubar.gameObject.activeSelf == false)
            {
                Menubar.SetActive(true);
                Time.timeScale = 0;
            }       
           
           else if (Menubar.gameObject.activeSelf == true)
            { 
                Menubar.SetActive(false);
                Time.timeScale = 1;
                
            }
        }
    
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        Menubar.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    public void NextLevelLoad()
    {
        SceneManager.LoadScene(NextLevelName);
    }

}
