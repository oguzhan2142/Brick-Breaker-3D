using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;


[System.Serializable]
public class SaveScore
{

    private const string PATH = "/scores.dat";

    public List<int> scores;


    public SaveScore()
    {
        loadSave();
    }



    public void saveScore(int score)
    {
        if (scores == null)
        {
            scores = new List<int>();
        }
        scores.Add(score);

        SaveScore save = new SaveScore();
        save.scores = this.scores;


        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + PATH);
        bf.Serialize(file, save);
        file.Close();

    }


    public List<int> getHighScores()
    {
        List<int> highScores = new List<int>();
        Comparison<int> comparison = new Comparison<int>(compareNumbers);


        scores.Sort(comparison);

        var index = 0;
        foreach (var score in scores)
        {
            if (index == 10)
                break;

            if (!highScores.Contains(score))
            {
                index++;
                highScores.Add(score);
            }

        }

        return highScores;
    }

    public void loadSave()
    {
        if (File.Exists(Application.persistentDataPath + PATH))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + PATH, FileMode.Open);
            SaveScore saveScore = (SaveScore)bf.Deserialize(file);
            this.scores = saveScore.scores;
            file.Close();
        }
    }


    private int compareNumbers(int a, int b)
    {
        if (a > b)
            return -1;
        else if (b > a)
            return 1;
        else
            return 0;
    }
}
