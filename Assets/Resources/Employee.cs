using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Employee
{
    [XmlAttribute("id")]
    public int id;
    [XmlElement("Lastname")]
    public string Lastname;
    [XmlElement("Firstname")]
    public string Firstname;
    [XmlElement("Age")]
    public int Age;
    [XmlElement("Job")]
    public string Job;
    [XmlElement("Salary")]
    public int Salary;
    [XmlElement("Skill-1")]
    public int Skill1;
    [XmlElement("Skill-2")]
    public int Skill2;
    [XmlElement("Skill-3")]
    public int Skill3;
}
