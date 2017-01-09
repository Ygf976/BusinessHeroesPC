using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//The goal of this class is to create the hirable employees
public class EmployeeScript : MonoBehaviour
{
    public Loader loader;
    public GameObject[] Cards;
    private Employee[] listEmployees = new Employee[9];
    private string[] lastnameList = new string[] {"Smith","Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson", "Thomas", "Jackson", "White", "Harris", "Martin", "Thompson", "Garcia", "Martinez", "Robinson", "Clark", "Rodriguez", "Lewis", "Lee", "Walker", "Hall", "Allen", "Young", "Hernandez", "King" };
    private string[] firstnameListM = new string[] { "James", "John", "Robert", "Michael", "William", "David", "Richard", "Charles", "Joseph", "Thomas", "Christopher", "Daniel", "Paul", "Mark", "Donald", "George", "Kenneth", "Steven", "Edward", "Brian", "Ronald", "Anthony", "Kevin", "Jason", "Matthew", "Gary", "Timothy", "Jose", "Larry", "Jeffrey" };
    private string[] firstnameListF = new string[] { "Mary", "Patricia", "Linda", "Barbara", "Elizabeth", "Jennifer", "Maria", "Susan", "Margaret", "Dorothy", "Lisa", "Nancy", "Karen", "Betty", "Helen", "Sandra", "Donna", "Carol", "Ruth", "Sharon", "Michelle", "Laura", "Sarah", "Kimberly", "Deborah", "Jessica", "Shirley", "Cynthia", "Angela", "Melissa" };

    void Start()
    {
        createCard();

    }

    //Generate 9 employees's card
    public void createCard()
    {   
        //Creation of employees
        for (int i = 0; i < 9; i++)
        {
            //Male
            if (Random.value > 0.5f)
            {
                listEmployees[i] = new Employee() { id = i, Firstname = firstnameListM[(int)Random.Range(0, 29)], Lastname = lastnameList[(int)Random.Range(0, 29)], Age = 20 + (int)(Random.Range(0, 30)), Job = "", Salary = 0, Skill1 = (int)Random.Range(0, 5), Skill2 = (int)Random.Range(0, 5), Skill3 = (int)Random.Range(0, 5) };
            }
            //Female
            else
            {
                listEmployees[i] = new Employee() { id = i, Firstname = firstnameListF[(int)Random.Range(0, 29)], Lastname = lastnameList[(int)Random.Range(0, 29)], Age = 20 + (int)(Random.Range(0, 30)), Job = "", Salary = 0, Skill1 = (int)Random.Range(0, 5), Skill2 = (int)Random.Range(0, 5), Skill3 = (int)Random.Range(0, 5) };
            }
        }

        
        for(int j=0; j<9; j++)
        {
            
            // Text :
            // 0 -> Name
            Cards[j].GetComponentsInChildren<Text>()[0].text += listEmployees[j].Firstname + " " + listEmployees[j].Lastname;
            // 1 -> Age
            Cards[j].GetComponentsInChildren<Text>()[1].text += listEmployees[j].Age.ToString();
            // 2 -> Profession
            Cards[j].GetComponentsInChildren<Text>()[2].text += listEmployees[j].Job;
            // 6 -> Salary
            Cards[j].GetComponentsInChildren<Text>()[6].text += listEmployees[j].Salary.ToString();

            //Image :
            Cards[j].GetComponentsInChildren<Image>()[1].sprite = new Sprite();

            //Skills :
            Cards[j].GetComponentsInChildren<Image>()[2].fillAmount = listEmployees[j].Skill1 / 5f;
            Cards[j].GetComponentsInChildren<Image>()[3].fillAmount = listEmployees[j].Skill2 / 5f;
            Cards[j].GetComponentsInChildren<Image>()[4].fillAmount = listEmployees[j].Skill3 / 5f;
            
        }


    }


    //Save the employees in Save.xml
    public void saveEmployee(int cardNumber)
    {

        loader.getCollection().Saves[PlayerPrefs.GetInt("savenumber")].Employees.Add(listEmployees[cardNumber]);
        loader.save();
    }

}
