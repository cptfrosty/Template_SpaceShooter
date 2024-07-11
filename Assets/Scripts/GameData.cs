using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameData : MonoBehaviour
{
    public static event UnityAction<int> ScoreChanged;

    public static int Score { 
        get 
        { 
            return s_score; 
        } 
        set 
        { 
            s_score = value;
            ScoreChanged?.Invoke(s_score);
        } 
    }
    private static int s_score;
}
