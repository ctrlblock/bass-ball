using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginnerRandomSongSupplier : SongSupplier {

    bool thisNote = false;

    public BeginnerRandomSongSupplier() {
        setNoteCount(30);
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
        return noteString;
    }

    override
    public double getSongSpeed()
    {
        return base.getSongSpeed() / 2;
    }
}
