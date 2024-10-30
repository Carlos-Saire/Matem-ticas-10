using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Position", menuName = "Scriptable Object/Position")]
public class PositionTable : ScriptableObject
{
    public List<float> highScores = new List<float>();
    public int maxScores;
    public void AddNewScore(float newScore)
    {
        highScores.Add(newScore);
        highScores.Sort();
        highScores.Reverse();
        if (highScores.Count > maxScores)
        {
            highScores.RemoveAt(highScores.Count - 1);
        }
    }
}