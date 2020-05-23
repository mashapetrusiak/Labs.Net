using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class TeamListHandlerEventArgs : EventArgs
    {
        #region Properties

        public string CollectionName { get; set; }
        public string CollectionChangeType { get; set; }
        public int NumberChangeOfElement { get; set; }

        #endregion

        #region Constructors

        public TeamListHandlerEventArgs(string collectionName, string collectionType, int number)
        {
            CollectionName = collectionName;
            CollectionChangeType = collectionType;
            NumberChangeOfElement = number;
        }
        #endregion


        #region Methods

        public override string ToString()
        {
            return Environment.NewLine +
                $"Collection: {CollectionName}" +
                Environment.NewLine +
                $"Type of change: {CollectionChangeType}" +
                Environment.NewLine +
                $"Index of element: {NumberChangeOfElement}";

        }

        #endregion


    }
}
