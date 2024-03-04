using System.Collections;
using System.Collections.Generic;

public abstract class SongSupplier {

	private double songSpeed = 2.5;

	private int noteCount = 80;

	public abstract string songUpdate(int time);
	public virtual double getSongSpeed() { return songSpeed; }

	public int getNoteCount() { return noteCount; }

    public void setNoteCount(int noteCount) { this.noteCount = noteCount; }

}
