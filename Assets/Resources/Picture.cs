using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Picture
{
    [XmlElement("path")]
    public string Path;
    [XmlElement("type")]
    public string Type;
}
