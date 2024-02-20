using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyRandomSongSupplier : SongSupplier
{
    bool thisNote = false;

    override
    public string songUpdate(int time)
    {
        thisNote = !thisNote;
        if (thisNote)
        {
            string note = GenerateNextNote();
            return note;
        }
        return null;
    }

    string GenerateNextNote()
    {
        int note = ((int)(Random.value * 3)) % 3;
        string noteString = note.ToString();
        if (note < 2)
        {
            int secondNote = ((int)(Random.value * 2)) % 2;
            if (secondNote == 1)
                noteString += (note + 1).ToString();
        }
        return noteString;
    }
}
