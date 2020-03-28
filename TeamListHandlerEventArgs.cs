using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class TeamListHandlerEventArgs :  EventArgs
    {
        #region Properties

        public string NameOfActionCollection { get; set; }
        public string InformationOfActionCollection { get; set; }
        public int NumberOfElement { get; set; }

        #endregion

        #region Constructors

        public TeamListHandlerEventArgs():this(default,default,default)
        {

        }

        public TeamListHandlerEventArgs(string nameOfCollection, string information, int number)
        {
            NameOfActionCollection = nameOfCollection;
            InformationOfActionCollection = information;
            NumberOfElement = number;
        }

        #endregion


        #region Public Methods

        public override string ToString()
        {
            return Environment.NewLine +
                      $"Collection : {NameOfActionCollection}" +
                      Environment.NewLine +
                      $"Type of change : {InformationOfActionCollection}" +
                      Environment.NewLine +
                      $"Index of element : {NumberOfElement}";
            
        }

        #endregion

    }
}
