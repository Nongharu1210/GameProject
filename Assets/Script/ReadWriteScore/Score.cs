using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Score : MonoBehaviour
{
    static public int ItemQuestCollection;
    string[] text;
    void  createtext(){
        string path = Application.dataPath + "/score.txt";
        string score = "point : "+ItemQuestCollection;
        File.AppendAllText(path,score);
    }
    // Start is called before the first frame update

    void updatetext(){

    }
    void Start()
    {
        createtext();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
