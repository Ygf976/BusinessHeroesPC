using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIGameCreation : MonoBehaviour
{

    public GameObject Character_Tab;
    public GameObject Business_Tab;
    public GameObject Settings_Tab;
    public GameObject Current_Tab;

    public GameObject Comfirmation_Window;

    //profil picture
    public GameObject PictureChooser_Window;
    public Image Profil_Image;

    //business logo
    public GameObject LogoChooser_Window;
    public Image Logo_Image;

    //For save creation

    public Loader loadingscript;

    public Text Lastname;
    public Text Firstname;
    public Text Businessname;
    public Text Businessslogan;

    //ErrorBox
    public GameObject Errorbox;

    public string Comfirmation_Message;

    void Start()
    {
        Current_Tab = Character_Tab;
        Current_Tab.SetActive(true);
    }

    //Display the Tab asked
    public void Tab_Click(string msg)
    {
        switch (msg)
        {
            case "Character_Button":
                Current_Tab.SetActive(false);
                Current_Tab = Character_Tab;
                Current_Tab.SetActive(true);
                return;
            case "Business_Button":
                Current_Tab.SetActive(false);
                Current_Tab = Business_Tab;
                Current_Tab.SetActive(true);
                return;
            case "Settings_Button":
                Current_Tab.SetActive(false);
                Current_Tab = Settings_Tab;
                Current_Tab.SetActive(true);
                return;
            case "Quit_Button":
                Comfirmation_Window.SetActive(true);
                Comfirmation_Message = "Menu";
                return;
            case "Play_Button":
                Comfirmation_Window.SetActive(true);
                Comfirmation_Message = "Game";
                return;
            case "Yes_Button":
                if(Comfirmation_Message=="Game")
                {
                    CreateGame();
                }
                if (Comfirmation_Message == "Menu")
                {
                    SceneManager.LoadScene(Comfirmation_Message);
                }
                return;
            case "No_Button":
                Comfirmation_Window.SetActive(false);
                return;
            default:
                return;
        }
    }


    //Select a profil picture
    public void PictureChooser_Click()
    {
        PictureChooser_Window.SetActive(true);
    }

    public void SelectPicture_Click(GameObject selectedbutton)
    {
        
        Profil_Image.sprite = selectedbutton.GetComponent<Image>().sprite;
        PictureChooser_Window.SetActive(false);
    }

    public void QuitPictureChooser_Click()
    {
        PictureChooser_Window.SetActive(false);
    }

    // Select a logo of the business

    public void LogoChooser_Click()
    {
        LogoChooser_Window.SetActive(true);
    }

    public void SelectLogo_Click(GameObject selectedbutton)
    {

        Logo_Image.sprite = selectedbutton.GetComponent<Image>().sprite;
        LogoChooser_Window.SetActive(false);
    }

    public void QuitLogoChooser_Click()
    {
        LogoChooser_Window.SetActive(false);
    }

    public void CreateGame()
    {
        // creation of the save (max 3 saves)
        Collection pc = loadingscript.getCollection();
        if (Lastname.text.Equals("")==false&& Firstname.text.Equals("") == false && Businessname.text.Equals("") == false && Businessslogan.text.Equals("") == false)
        {
            Save s = new Save();
            s.id = pc.Saves.Count;
            s.Lastname = Lastname.text;
            s.Firstname = Firstname.text;
            s.ProfilPicture = Profil_Image.sprite.name;
            s.BusinessName = Businessname.text;
            s.BusinessSlogan = Businessslogan.text;
            s.BusinessLogo = Logo_Image.sprite.name;
            s.BusinessType = "GameCreation";
            pc.Saves.Add(s);
            loadingscript.save();
            SceneManager.LoadScene(Comfirmation_Message);
        }
        else
        {
            Comfirmation_Window.SetActive(false);
            if (Lastname.text.Equals(""))
            {
                Errorbox.SetActive(true);
                Errorbox.GetComponentInChildren<Text>().text = "Lastname not given";
            }
            else if (Firstname.text.Equals(""))
            {
                Errorbox.SetActive(true);
                Errorbox.GetComponentInChildren<Text>().text = "Firstname not given";
            }
            else if(Businessname.text.Equals(""))
            {
                Errorbox.SetActive(true);
                Errorbox.GetComponentInChildren<Text>().text = "Business name not given";
            }
            else if(Businessslogan.text.Equals(""))
            {
                Errorbox.SetActive(true);
                Errorbox.GetComponentInChildren<Text>().text = "Business slogan not given";
            }
        }

    }

    public void closeError()
    {
        Errorbox.SetActive(false);
    }


}
