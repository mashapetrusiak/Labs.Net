using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class TeamsJournalEntry
    {
        #region Properties

        public string EventCollection { get; set; }
        public string TypeOfEvent { get; set; }
        public int IndexOfElement { get; set; }



        #endregion

        #region Constructors

        public TeamsJournalEntry(string collection, string typeEvent, int numberOfElement)
        {
            EventCollection = collection;
            TypeOfEvent = typeEvent;
            IndexOfElement = numberOfElement;
        }

        public TeamsJournalEntry() : this(default, default, default)
        {
        }
        #endregion


        #region Methods

        public override string ToString()
        {
            return Environment.NewLine +
                   $"Collection : {EventCollection}" +
                   Environment.NewLine +
                   $"Type of change : {TypeOfEvent}" +
                   Environment.NewLine +
                   $"Index of element : {IndexOfElement}";
        }

        #endregion


    }
}
