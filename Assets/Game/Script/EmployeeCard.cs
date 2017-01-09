using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//The goal of this class is to manage the creation of employee card

public class EmployeeCard : MonoBehaviour {

    private string Picturepath;
    private string Name;
    private int Age;
    private string Profession;
    private int Salary;

    private int Skill1;
    private int Skill2;
    private int Skill3;

    //Card's constructor
    public EmployeeCard(string picturepat, string nam, int ag, string professio, int salar, int skil1, int skil2, int skil3)
    {
        Picturepath = picturepat;
        Name = nam;
        Age = ag;
        Profession = professio;
        Salary = salar;
        Skill1 = skil1;
        Skill2 = skil2;
        Skill2 = skil3;
    }


    //Method used to create the card as a gameobject
    public GameObject createCard()
    {
        GameObject card = Resources.Load<GameObject>("employee_card");
        Text[] texts = card.GetComponentsInChildren<Text>();
        Image[] images = card.GetComponentsInChildren<Image>();


        // I1: profil pic / I2: skill1 / I3: skill2 / I4: skill3
        // T0: name / T1: age / T2: profession / T6: salary

        images[1].sprite = Resources.Load<Sprite>(Picturepath);
        images[2].fillAmount = Skill1 / 5f;
        images[3].fillAmount = Skill2 / 5f;
        images[4].fillAmount = Skill3 / 5f;

        texts[0].text = Name;
        texts[1].text = Age.ToString();
        texts[2].text = Profession;
        texts[6].text = Salary.ToString();

        return card;
    }
}
