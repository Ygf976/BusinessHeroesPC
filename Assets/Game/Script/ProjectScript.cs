using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//This class manage the projects
public class ProjectScript : MonoBehaviour
{
    public GameObject[] Cards;
    private Project[] listProject = new Project[4];
    
    void Start()
    {
        createCard();

    }

    //Generate 4 project's card
    public void createCard()
    {
        //Creation of project
        for (int i = 0; i < 9; i++)
        {
            listProject[i] = new Project() { /* project details */ };
        }


        for (int j = 0; j < 9; j++)
        {

            // Text :
            Cards[j].GetComponentsInChildren<Text>()[0].text += "";
            
            //Image :
            Cards[j].GetComponentsInChildren<Image>()[1].sprite = new Sprite();

        }


    }

}
