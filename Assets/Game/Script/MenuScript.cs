using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


//This is the class responsible for the Menu scene's UI.
public class MenuScript : MonoBehaviour {

    public GameObject Load_Window;
    public Loader LoaderScript;
    public GameObject Save_1;
    public GameObject Save_2;
    public GameObject Save_3;
    public GameObject ComfirmWindow;
    public GameObject ErrorBox;
    public int SaveDel;

    void Start()
    {
        
    }

    //Start a new game
	public void create_click()
    {
        LoaderScript.load();
        Collection pc = LoaderScript.getCollection();
        if (pc.Saves.Count < 3)
        {
            SceneManager.LoadScene("GameCreation");
        }
        else
        {
            ErrorBox.SetActive(true);
        }   
    }

    public void boxclose()
    {
        ErrorBox.SetActive(false);
    }

    //Load a save
    public void load_click()
    {
        LoaderScript.load();
        Collection pc = LoaderScript.getCollection();
        if (pc.Saves.Count>0)
        {
            Save_1.GetComponentsInChildren<Image>()[1].sprite = (Sprite)Resources.Load<Sprite>("Pictures\\" + pc.Saves[0].ProfilPicture);
            Save_1.GetComponentInChildren<Text>().text = pc.Saves[0].Lastname + "\r\n" + pc.Saves[0].Firstname + "\r\n" + pc.Saves[0].BusinessName;
            if (pc.Saves.Count > 1)
            {
                
                Save_2.GetComponentsInChildren<Image>()[1].sprite = (Sprite)Resources.Load<Sprite>("Pictures\\" + pc.Saves[1].ProfilPicture);
                Save_2.GetComponentInChildren<Text>().text = pc.Saves[1].Lastname + "\r\n" + pc.Saves[1].Firstname + "\r\n" + pc.Saves[1].BusinessName;
                if (pc.Saves.Count > 2)
                {
                    Save_3.GetComponentsInChildren<Image>()[1].sprite = (Sprite)Resources.Load<Sprite>("Pictures\\" + pc.Saves[2].ProfilPicture);
                    Save_3.GetComponentInChildren<Text>().text = pc.Saves[2].Lastname + "\r\n" + pc.Saves[2].Firstname + "\r\n" + pc.Saves[2].BusinessName;
                }
            }
        }
        Load_Window.SetActive(true);
    }

    //Comfirmation window
    public void confirm_click(int SaveNumber)
    {
        if (LoaderScript.getCollection().Saves.Count >= SaveNumber)
        {
            PlayerPrefs.SetInt("Save", SaveNumber);
            SceneManager.LoadScene("Game");
        }
        else
        {
            Debug.Log("Error");
        }
    }

    public void no_click()
    {
        Load_Window.SetActive(false);
    }

    //Delete window
    public void delete(int SaveNumber)
    {
        Collection pc = LoaderScript.getCollection();
        if (pc.Saves.Count >= SaveNumber)
        {
            ComfirmWindow.SetActive(true);
            SaveDel = SaveNumber;
        }
    }

    //Delete method
    public void ComfirmDelete()
    {
        Collection pc = LoaderScript.getCollection();
        pc.Saves.Remove(pc.Saves[SaveDel - 1]);
        LoaderScript.save();
        if (Save_2.GetComponentInChildren<Text>().text == "Save Available")
        {
            Save_1.GetComponentsInChildren<Image>()[1].sprite = (Sprite)Resources.Load<Sprite>("Pictures\\Plus");
            Save_1.GetComponentInChildren<Text>().text = "Save Available";

        }
        if (Save_3.GetComponentInChildren<Text>().text == "Save Available")
        {
            Save_2.GetComponentsInChildren<Image>()[1].sprite = (Sprite)Resources.Load<Sprite>("Pictures\\Plus");
            Save_2.GetComponentInChildren<Text>().text = "Save Available";
        }
        else
        {
            Save_3.GetComponentsInChildren<Image>()[1].sprite = (Sprite)Resources.Load<Sprite>("Pictures\\Plus");
            Save_3.GetComponentInChildren<Text>().text = "Save Available";
        }
        ComfirmWindow.SetActive(false);
        Load_Window.SetActive(false);
        load_click();
    }

    public void cancelDel()
    {
        ComfirmWindow.SetActive(false);
    }
}
