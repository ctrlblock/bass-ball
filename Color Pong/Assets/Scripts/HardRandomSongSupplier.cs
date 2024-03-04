using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardRandomSongSupplier : SongSupplier
{
    bool thisNote = false;

    public HardRandomSongSupplier()
    {
        setNoteCount(80);
    }


    override
    public string songUpdate(int time)
    {
        string note = GenerateNextNote();
        return note;
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

    override
    public double getSongSpeed()
    {
        return base.getSongSpeed() * 1.25;
    }
}
