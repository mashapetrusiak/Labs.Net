using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class TeamsJournalEntry
    {
        #region Properties

        public string Name { get; set; }
        public string InformationOfChange { get; set; }
        public int NumberOfNewElement { get; set; }

        #endregion

        #region Constructors

        public TeamsJournalEntry(string name, string information, int number)
        {
            Name = name;
            InformationOfChange = information;
            NumberOfNewElement = number;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"Collection: {Name}\t Type of change: {InformationOfChange} \t Index of element: {NumberOfNewElement}\n";
        }

        #endregion
    }
}
