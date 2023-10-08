using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningSequence
{
    public String[] winningSequence_1 = {"1:1","1:2","1:3"};
    public String[] winningSequence_2 = {"2:1","2:2","2:3"};
    public String[] winningSequence_3 = {"3:1","3:2","3:3"};
    public String[] winningSequence_4 = {"1:1","2:1","3:1"};
    public String[] winningSequence_5 = {"1:2","2:2","3:2"};
    public String[] winningSequence_6 = {"1:3","2:3","3:3"};
    public String[] winningSequence_7 = {"1:1","2:2","3:3"};
    public String[] winningSequence_8 = {"1:3","2:2","3:1"};
    public List<string[]> WinningSeqList { get; private set; }

    public WinningSequence()
    {
        // Initialize the list in the constructor and add the winning sequences
        WinningSeqList = new List<string[]>
        {
            winningSequence_1,
            winningSequence_2,
            winningSequence_3,
            winningSequence_4,
            winningSequence_5,
            winningSequence_6,
            winningSequence_7,
            winningSequence_8
        };
    }
    
}
