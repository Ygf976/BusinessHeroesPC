using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour {

    public GameObject Character_Tab;
    public GameObject Office_Tab;
    public GameObject Employees_Tab;
    public GameObject Projects_Tab;
    public GameObject Finances_Tab;
    public GameObject Settings_Tab;
    public GameObject Current_Tab;

    public GameObject Comfirmation_Window;
    public GameObject EmployeeChooser_Window;
    public GameObject ProjectChooser_Window;

    public GameObject RightCard;
    public GameObject employee_grid;
    public GameObject MainRight;

    private int play=1;
    public TimeScript ts;
    public GameObject TimeIcon;
    public Text date_text; 

    public EmployeeScript employeescript;
    public string Comfirmation_Message;

    void Start()
    {
        Current_Tab=Character_Tab;
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
            case "Office_Button":
                Current_Tab.SetActive(false);
                Current_Tab = Office_Tab;
                Current_Tab.SetActive(true);
                return;
            case "Employees_Button":
                Current_Tab.SetActive(false);
                Current_Tab = Employees_Tab;
                Current_Tab.SetActive(true);
                return;
            case "Projects_Button":
                Current_Tab.SetActive(false);
                Current_Tab = Projects_Tab;
                Current_Tab.SetActive(true);
                return;
            case "Finances_Button":
                Current_Tab.SetActive(false);
                Current_Tab = Finances_Tab;
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
            case "Yes_Button":
                SceneManager.LoadScene(Comfirmation_Message);
                return;
            case "No_Button":
                Comfirmation_Window.SetActive(false);
                return;
            default:
                return;
        }
    }

    //Open and close the employee chooser
    public void EmployeeChooser_Click()
    {
        EmployeeChooser_Window.SetActive(true);
    }


    public void QuitEmployeeChooser_Click()
    {
        EmployeeChooser_Window.SetActive(false);
    }

    public void ProjectChooser_Click()
    {
        ProjectChooser_Window.SetActive(true);
    }


    public void QuitProjectChooser_Click()
    {
        ProjectChooser_Window.SetActive(false);
    }


    //Employees

    //Hire:

    public void hire(int cardNumber)
    {
        //save employee
        //employeescript.saveEmployee(cardNumber);
        //set the card
        GameObject card = GameObject.Find("Employee_Card" + cardNumber.ToString());
        card.transform.SetParent(employee_grid.GetComponent<RectTransform>());
        card.GetComponent<Button>().onClick.AddListener(delegate () { employeeSelection(card); });

    }

    public void setPosition(GameObject card)
    {

    }


    //Select a card

    public void employeeSelection(GameObject card)
    {
        Destroy(RightCard);
        RightCard = (GameObject)Instantiate(card, MainRight.transform.position, MainRight.transform.rotation);
        RightCard.transform.SetParent(MainRight.GetComponent<RectTransform>());
        RightCard.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        
    }

    //Time Controls

    public void play_button()
    {
        if (play == 0)
        {
            ts.Play_Speed();
            TimeIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons\\Play");
            play = 1;
        }
        else
        {
            ts.Play_Speed();
            play = 0;
            TimeIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons\\Pause");
        }
    }

    public void setDate(int day,int month, int year)
    {
        switch (month)
        {
            case 1:
                date_text.text = day.ToString() + " / Jan /  " + year.ToString();
                return;
            case 2:
                date_text.text = day.ToString() + " / Feb /  " + year.ToString();
                return;
            case 3:
                date_text.text = day.ToString() + " / Mar /  " + year.ToString();
                return;
            case 4:
                date_text.text = day.ToString() + " / Apr /  " + year.ToString();
                return;
            case 5:
                date_text.text = day.ToString() + " / May /  " + year.ToString();
                return;
            case 6:
                date_text.text = day.ToString() + " / Jun /  " + year.ToString();
                return;
            case 7:
                date_text.text = day.ToString() + " / Jul /  " + year.ToString();
                return;
            case 8:
                date_text.text = day.ToString() + " / Aug /  " + year.ToString();
                return;
            case 9:
                date_text.text = day.ToString() + " / Sep /  " + year.ToString();
                return;
            case 10:
                date_text.text = day.ToString() + " / Oct /  " + year.ToString();
                return;
            case 11:
                date_text.text = day.ToString() + " / Nov /  " + year.ToString();
                return;
            case 12:
                date_text.text = day.ToString() + " / Dec /  " + year.ToString();
                return;
        }
    }
}
