using Microsoft.TeamFoundation.Work.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    public enum TimeFrame
    {
        Year,
        TwoYears,
        Long
    }

    public class ResearchTeam
    {
        private string _researchTopic;
        private string _organization;
        private int _registerNumber;
        private TimeFrame _timeFrame;
        private Paper[] _listOfPublication;

        public string ResearchTopic 
        {
            get { return _researchTopic; } 
            set { _researchTopic = value; } 
        }
        public string Organization
        {
            get { return _organization; }
            set { _organization = value; }
        }
        public int RegisterNumber
        {
            get { return _registerNumber; }
            set { _registerNumber = value; }
        }

        public TimeFrame TimeFrame
        {
            get { return _timeFrame; }
            set { _timeFrame = value; }
        }
                

        public Paper[] ListOfPublication 
        {
            get { return _listOfPublication; }
            set { _listOfPublication = value; }
        }


        public ResearchTeam(string resTopic, string organization, int regNumber, TimeFrame timeFrame, Paper[] listOfPublication)
        {
            ResearchTopic = resTopic;
            Organization = organization;
            RegisterNumber = regNumber;
            TimeFrame = timeFrame;
            ListOfPublication = listOfPublication;
        }

            
        public ResearchTeam():this("default","defualt",0,0,default)
        {            
        }

        public Paper LastPublication 
        {
            get
            {
                if (ListOfPublication != null)
                    return ListOfPublication.Last();
                else
                    return null;
            }
        }

        public bool this[TimeFrame time]
        {
            get
            {
                return time == TimeFrame;
            }
        }

        public void AddPapers(params Paper[] papers)
        {
            int startCountOfPublication = _listOfPublication.Length;
            Array.Resize(ref _listOfPublication, _listOfPublication.Length + papers.Length);
            for (int i = startCountOfPublication, j = 0; i < _listOfPublication.Length; i++, j++)
            {
                _listOfPublication[i] = papers[j];
            }
        }

        public override string ToString()
        {                                   
            StringBuilder builder = new StringBuilder(ToShortString());
            builder.Append("ListOfPublication: ");

            for(int i = 0; i < ListOfPublication.Length;i++)
            {
                builder.Append($"{ListOfPublication[i].ToString()},  ");
            }            
            return builder.ToString();
        }

        public virtual string ToShortString()
        {
            var data = $"Organization: {Organization} | Topic: {ResearchTopic} | Register number: {RegisterNumber} | TimeFrame: {TimeFrame} ";
            return data;
        }

    }
}
