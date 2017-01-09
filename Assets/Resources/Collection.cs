using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;

[XmlRoot("Collection")]
public class Collection {

    [XmlArray("Saves")]
    [XmlArrayItem("Save")]
    public List<Save> Saves;

    [XmlArray("Pictures")]
    [XmlArrayItem("Picture")]
    public List<Picture> Pictures;

    

    

    public static Collection Load(string path)
    {


        if (File.Exists(path) == false)
        {
            TextAsset _xml = Resources.Load<TextAsset>("Collection");
            var serializere = new XmlSerializer(typeof(Collection));
            using (var reader = new StringReader(_xml.text))
            {
                Collection cont = serializere.Deserialize(reader) as Collection;
                using (var writer = new FileStream(path, FileMode.Create))
                {
                    serializere.Serialize(writer, cont);
                }
            }

        }
        var serializer = new XmlSerializer(typeof(Collection));
        using (var reader = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(reader) as Collection;
        }

    }

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(Collection));
        using (var writer = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(writer, this);
        }
    }
}
