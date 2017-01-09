using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System;

public class Save
{
    //Profil
    [XmlAttribute("id")]
    public int id;
    [XmlElement("Lastname")]
    public string Lastname;
    [XmlElement("Firstname")]
    public string Firstname;
    [XmlElement("ProfilPicture")]
    public string ProfilPicture;

    //Business
    [XmlElement("BusinessType")]
    public string BusinessType;
    [XmlElement("BusinessName")]
    public string BusinessName;
    [XmlElement("BusinessSlogan")]
    public string BusinessSlogan;
    [XmlElement("BusinessLogo")]
    public string BusinessLogo;

    //Date
    [XmlElement("Year")]
    public int Year;
    [XmlElement("Month")]
    public int Month;
    [XmlElement("Day")]
    public int Day;

    //XP
    [XmlElement("Level")]
    public int Level;
    [XmlElement("Experience")]
    public int Experience;
    [XmlElement("RemainingExperience")]
    public int RemainingExperience;

    //Money
    [XmlElement("PersonalMoney")]
    public int PersonalMoney;
    [XmlElement("BusinessMoney")]
    public int BusinessMoney;
    [XmlElement("BusinessIncome")]
    public int BusinessIncome;
    [XmlElement("PersonalIncome")]
    public int PersonalIncome;

    //Employees
    [XmlArray("Employees")]
    [XmlArrayItem("Employee")]
    public List<Employee> Employees;

    //Projects
    [XmlArray("Projects")]
    [XmlArrayItem("Project")]
    public List<Project> Projects;


}
