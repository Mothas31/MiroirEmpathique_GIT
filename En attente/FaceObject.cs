using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using UnityEditor.VersionControl;

/// <summary>
/// A C# representation of the Face API from Microsoft Cognitive Services
/// Written by Livi Erickson (@missLiviRose)
/// </summary>
[System.Serializable]

public class FaceObject : MonoBehaviour
{
    public Dialogue dialogue;
    public string faceRectangle { get; private set; }
    public List<Emotion> emotions { get; private set; }
    public string put2;

    void Start()
    {
        dialogue = gameObject.GetComponentInParent<Dialogue>();
    }

    public FaceObject(string rect, string scorelist)
    {
        faceRectangle = rect;
        emotions = ConvertScoresToEmotionDictionary(scorelist);
        string put = GetHighestWeighedEmotion().ToString();
        string put2 = "";
        int i = 0;
        char temp = put[i];
        
        while(temp != ':')
        {
            put2 += temp;
            i++;
            temp = put[i];
        }
        // dialogue.ChoixEmotion(put2);
        //dialogue.ChoixEmotion();
        // Debug.Log("Highest Emotion: " + GetHighestWeighedEmotion().ToString());
        Debug.Log("Highest Emotion:put2 " + put2);
        // gameObject.SendMessage("ChoixEmotion", put2);
        envoichize(put2);
    }
    /// <summary>
    /// Convert a JSON-formatted string from the Emotion API call into a List of Emotions
    /// </summary>
    /// <param name="scores"></param>
    /// <returns></returns>
    public List<Emotion> ConvertScoresToEmotionDictionary(string scores)
    {
        List<Emotion> emotes = new List<Emotion>();
        JSONObject _scoresJSON = new JSONObject(scores);
        for(int i = 0; i < _scoresJSON.Count; i++)
        {

            Emotion e = new Emotion(_scoresJSON.keys[i], float.Parse(_scoresJSON.list[i].ToString()));
            emotes.Add(e);
            Debug.Log("I : " + i);
        }
        return emotes;
    }

    /// <summary>
    /// Get the highest scored emotion 
    /// </summary>
    /// <returns></returns>
    public Emotion GetHighestWeighedEmotion()
    {
        Emotion max = emotions[0];
        Debug.Log("Emotion 0 : " + emotions[0]);
        Debug.Log("Emotion 1 : " + emotions[1]);
        Debug.Log("Emotion 2 : " + emotions[2]);
        Debug.Log("Emotion 3 : " + emotions[3]);
        Debug.Log("Emotion 4 : " + emotions[4]);
        Debug.Log("Emotion 5 : " + emotions[5]);
        Debug.Log("Emotion 6 : " + emotions[6]);
        Debug.Log("Emotion 7 : " + emotions[7]);
        foreach (Emotion e in emotions)
        {
            if(e.value > max.value)
            {
                max = e;
            }
        }
        Debug.Log("max : " + max.name);
   

       // put2 = max.name;
        
        return max;
        
    }

    public void envoichize(string put2)
    {
        Debug.Log("Test envoi chize " + put2);
        dialogue.ChoixEmotion2();
       // gameObject.GetComponentInParent<Dialogue>().SendMessage("ChoixEmotion", put2);
    }

}

/// <summary>
///  A helper class for storing an emotion
///  From the spec of the Cognitive Services API
/// </summary>
public class Emotion
{
    public string name { get; private set; }
    public float value { get; private set; }

    public Emotion(string name, float value)
    {
        this.name = name;
        this.value = value;
    }

    override public string ToString()
    {
        return name + " : " + value;
    }



}



