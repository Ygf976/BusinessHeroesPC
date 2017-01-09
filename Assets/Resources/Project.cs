using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System;
public class Project
{
    //Description
    [XmlAttribute("id")]
    public int id;
    [XmlElement("Client")]
    public string Client;
    [XmlElement("ClientPicture")]
    public string ClientPicture;
    [XmlElement("Details")]
    public string Details;
    [XmlElement("AwardMoney")]
    public int AwardMoney;
    [XmlElement("AwardXp")]
    public int AwardXp;
    [XmlElement("SizeHours")]
    public int SizeHours;
    [XmlElement("Deadline")]
    public int Deadline;
    [XmlElement("StartingEvent")]
    public Event StartingEvent;

    //Status
    [XmlElement("Active")]
    public int Active;
    [XmlElement("ProgressStatus")]
    public int ProgressStatus;
    [XmlElement("Progress")]
    public int Progress;

    //Award
    [XmlElement("MoneyAward")]
    public int MoneyAward;
    [XmlElement("XpAward")]
    public int XpAward;

    //Employees
    [XmlElement("Manager")]
    public string Manager;
    [XmlElement("Employee-1")]
    public string Employee1;
    [XmlElement("Employee-2")]
    public string Employee2;
    [XmlElement("Employee-3")]
    public string Employee3;
    [XmlElement("Employee-4")]
    public string Employee4;
    [XmlElement("Employee-5")]
    public string Employee5;

    //Events
    [XmlArray("Events")]
    [XmlArrayItem("Event")]
    public Event[] Events;

}
