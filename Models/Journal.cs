using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoApp.Models
{
    public enum MoodLevel
    {
        Happy = 0,
        Sad = 1,
        Excited = 2,
        Anxious = 3,
        Neutral = 4
    }

    public class JournalEntry
    {
        public DateTime Date { get; set; }
        public MoodLevel Mood { get; set; }
        public string Text { get; set; }

        public JournalEntry(DateTime date, MoodLevel mood, string text)
        {
            Date = date;
            Mood = mood;
            Text = text;
        }

        public override string ToString()
        {
            return $"Date: {Date.ToShortDateString()}\nMood: {Mood}\nEntry: {Text}";
        }
    }
}