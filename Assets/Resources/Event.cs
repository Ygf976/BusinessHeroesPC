using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Event
{
    [XmlAttribute("id")]
    public int id;
    [XmlElement("Timer")]
    public int timer;
    [XmlElement("Effect")]
    public string effect;
    [XmlElement("Number")]
    public int number;
}
