using UnityEngine;

using System.Collections;

public class TimeScript : MonoBehaviour {

    private System.DateTime date;
    private Time time_since_start;
    private IEnumerator coroutine;
    public UIManagerScript uim;

    // Use this for initialization
    void Start () {
        //Load time from save:
        Save save = GameObject.FindObjectOfType<Loader>().getCollection().Saves[PlayerPrefs.GetInt("save")];
        date = new System.DateTime(save.Year, save.Month, save.Day);
        uim.setDate(save.Day, save.Month, save.Year);
    }
	
    //Method to set the speed of the game
    // 0 -> Pause
    // 1 -> Normal
    // 2 -> Fast
    // 3 -> Very Fast
    public void Play_Speed()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
        else
        {
            coroutine = Play_Speed_Coroutine();
            StartCoroutine(coroutine);
        }
    }


    //Coroutines for each speed
    private IEnumerator Play_Speed_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            date=date.AddDays(1);
            uim.setDate(date.Day, date.Month, date.Year);
            this.GetComponent<Loader>().getCollection().Saves[PlayerPrefs.GetInt("save")].Day = date.Day;
            this.GetComponent<Loader>().getCollection().Saves[PlayerPrefs.GetInt("save")].Month = date.Month;
            this.GetComponent<Loader>().getCollection().Saves[PlayerPrefs.GetInt("save")].Year = date.Year;
            this.GetComponent<Loader>().save();
        }
    }
    


}
