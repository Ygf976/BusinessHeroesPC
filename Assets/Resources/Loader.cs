using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

    
    private Collection pc;

    // Use this for initialization
    void Start()
    {
        load();
    }

    public void save()
    {
        //save settings


        //save process
        pc.Save(Application.persistentDataPath + "/Collection.xml");
    }

    public void load()
    {
        //load settings


        //load process
        pc = Collection.Load(Application.persistentDataPath + "/Collection.xml");
        setup();
    }

    public void setup()
    {
        //todo after loading

    }

    public Collection getCollection()
    {
        return pc;
    }
}
