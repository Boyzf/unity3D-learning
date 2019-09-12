using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe: MonoBehaviour {
    int turn = 1;
    int [,]state = new int[3,3];
    void Start ()
    {
        Reset();
    }

    void Update () { }

    void OnGUI()
    {
        if (GUI.Button(new Rect(110,250,120,40), "Begin"))
        {
            Reset();
        }
        int current = Check();
        if (current == 1) GUI.Label(new Rect(110, 305, 150, 150),"First players wins!");
        if (current == 2) GUI.Label(new Rect(110, 305, 150, 150),"Second player wins!");
        if (current == 3) GUI.Label(new Rect(110, 305, 150, 150),"No one wins!");
        for (int i = 0; i < 3; i ++)
        {
            for (int j = 0; j < 3; j ++)
            {
                if (state[i, j] == 1)
                {
                    GUI.Button(new Rect(100 + 50 * i, 80 + 50 * j, 40, 40), "O");
                } 
                else if (state[i, j] == 2)
                {
                    GUI.Button(new Rect(100 + 50 * i, 80 + 50 * j, 40, 40), "X");
                } 
                if (GUI.Button(new Rect(100 + 50 * i, 80 + 50 * j, 40, 40), ""))
                {
                    if (current == 0)
                    {
                        if (turn == 1) state[i, j] = 1;
                        if (turn == -1) state[i, j] = 2;
                        turn *= -1;
                    }
                }
            }
        }
    }

    int Check()
    {
        for (int i = 0; i < 3; i ++)
        {
            if (state[i, 0] == state[i, 1] && state[i, 0] == state[i, 2] && state[i, 0] != 0)
            {
                return state[i, 0];
            }
        }
        for (int j = 0; j < 3; j ++)
        {
            if (state[0, j] == state[1, j] && state[2, j] == state[0, j] && state[0, j] != 0)
            {
                return state[0, j];
            }
        }
        if (state[1, 1] != 0 && state[0, 0] == state[1, 1] && state[2, 2] == state[1, 1])
        {
            return state[1, 1];
        }
        if (state[1, 1] != 0 && state[0, 2] == state[1, 1] && state[2, 0] == state[1, 1])
        {
            return state[1, 1];
        }
        for (int i = 0; i < 3; i ++)
        {
            for (int j = 0; j < 3; j ++)
            {
                if (state[i, j] == 0) return 0;
            }
        }
        return 3;
    }

    void Reset()
    {
        turn = 1;
        for (int i = 0; i < 3; i ++)
        {
            for (int j = 0; j < 3; j ++)
            {
                state[i, j] = 0;
            }
        }
    }
}