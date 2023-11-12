using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ChangeScene : MonoBehaviour
{
    int score = 0;
    public Image button1image;
    public Image button2image;
    public Image button3image;
    public Button mybutton1;
    public TextMeshProUGUI Button1text;
    public Button mybutton2;
    public TextMeshProUGUI Button2text;
    public Button mybutton3;
    public TextMeshProUGUI Button3text;
    int i = 0;
    public TextMeshProUGUI Pitanje1Text;
    [System.Serializable]
    public class JsonObject
    {
        public string pitanje;
        public List<Odgovor> odgovori;
    }

    [System.Serializable]
    public class Odgovor
    {
        public string odgovor;
        public int vrednost;
    }

    [System.Serializable]
    public class JsonWrapper
    {
        public List<JsonObject> jsonArray;
    }

    string jsonArrayString = "[{\"pitanje\":\"Nekopitanje1\",\"odgovori\":[{\"odgovor\":\"Nekiodgovor1\",\"vrednost\":5},{\"odgovor\":\"Nekiodgovor2\",\"vrednost\":10}]},{\"pitanje\":\"Nekopitanje2\",\"odgovori\":[{\"odgovor\":\"Nekiodgovor1\",\"vrednost\":10},{\"odgovor\":\"Nekiodgovor2\",\"vrednost\":5},{\"odgovor\":\"Nekiodgovor3\",\"vrednost\":5}]}]";

    JsonWrapper jsonWrapper;

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Specific scene loaded: " + scene.name);
        if (scene.name == "pitanje1") // Replace with your scene name
        {
            PromeniPitanje();
            mybutton1.onClick.AddListener(OnButtonClick1);
            mybutton2.onClick.AddListener(OnButtonClick2);
            mybutton3.onClick.AddListener(OnButtonClick3);
        }
    }
    void PromeniPitanje()
    {

        // Deserialize JSON array into a JsonWrapper object
        jsonWrapper = JsonUtility.FromJson<JsonWrapper>("{\"jsonArray\":" + jsonArrayString + "}");

        // Access the list of JsonObjects from the JsonWrapper
        List<JsonObject> jsonArray = jsonWrapper.jsonArray;

        string pitanje = jsonArray[i].pitanje;
        Debug.Log(pitanje);
        Pitanje1Text.text = pitanje;

        int j = 0;

        Color color1 = button1image.color;
        color1.a = 0;  // Adjust this value for desired transparency
        button1image.color = color1;

        Color color2 = button2image.color;
        color2.a = 0;  // Adjust this value for desired transparency
        button2image.color = color2;

        Color color3 = button3image.color;
        color3.a = 0;  // Adjust this value for desired transparency
        button3image.color = color3;

        Button1text.text = "";
        Button2text.text = "";
        Button3text.text = "";

        //List<JsonObject> jsonOdgovori = jsonArray[i.odgovori];
        foreach (Odgovor odgovor in jsonArray[i].odgovori)
        {

            if (j == 0)
            {
                Button1text.text = odgovor.odgovor;
                color1.a = 100;
                button1image.color = color1;

            }
            else if (j == 1)
            {
                Button2text.text = odgovor.odgovor;
                color2.a = 100;
                button2image.color = color2;
            }
            else
            {
                Button3text.text = odgovor.odgovor;
                color3.a = 100;
                button3image.color = color3;
            }
            j++;
            //Debug.Log(odgovor.odgovor);
            //Debug.Log(odgovor.vrednost);
            //Button1text.text = odgovor.odgovor;
            //Button2text.text = odgovor.odgovor;
            //Button3text.text = odgovor.odgovor;

        }
        j = 0;

    }
    void OnButtonClick1()
    {
        jsonWrapper = JsonUtility.FromJson<JsonWrapper>("{\"jsonArray\":" + jsonArrayString + "}");

        // Access the list of JsonObjects from the JsonWrapper
        List<JsonObject> jsonArray = jsonWrapper.jsonArray;
        score = score + jsonArray[i].odgovori[0].vrednost;
        Debug.Log(jsonArray.Length);
        i++;
        PromeniPitanje();
    }

    void OnButtonClick2()
    {
        jsonWrapper = JsonUtility.FromJson<JsonWrapper>("{\"jsonArray\":" + jsonArrayString + "}");

        // Access the list of JsonObjects from the JsonWrapper
        List<JsonObject> jsonArray = jsonWrapper.jsonArray;
        score = score + jsonArray[i].odgovori[1].vrednost;
        //Debug.Log(score);
        i++;
        PromeniPitanje();
    }

    void OnButtonClick3()
    {
        jsonWrapper = JsonUtility.FromJson<JsonWrapper>("{\"jsonArray\":" + jsonArrayString + "}");

        // Access the list of JsonObjects from the JsonWrapper
        List<JsonObject> jsonArray = jsonWrapper.jsonArray;
        score = score + jsonArray[i].odgovori[2].vrednost;
        //Debug.Log(score);
        i++;
        PromeniPitanje();
    }



}




