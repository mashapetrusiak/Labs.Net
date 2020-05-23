using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    [DataContract]
    public class ResearchTeam : Team, INameAndCopy, IEnumerable, IComparer<ResearchTeam>
    {
        public enum TimeFrame
        {
            Year,
            TwoYears,
            Long
        }
        private string _researchTopic;
        private TimeFrame _durationResearch;

        [DataMember]
        public List<Person> ListOfMembers { get; set; }
        
        [DataMember]
        public List<Paper> ListOfPublications { get; set; }

        [DataMember]
        public string ResearchTopic
        {
            get { return _researchTopic; }
            set { _researchTopic = value; }
        }
        [DataMember]
        public TimeFrame DurationOfResearch
        {
            get { return _durationResearch; }
            set { _durationResearch = value; }
        }


        public Team team
        {
            get
            {
                return new Team(Organization, RegisterNumber);
            }
            set
            {
                Organization = value.Name;
                RegisterNumber = value.RegisterNumber;
            }
        }

        public Paper LastPublication
        {
            get
            {
                if (ListOfPublications == null)
                    return null;
                else
                    return (Paper)ListOfPublications[ListOfPublications.Count - 1];
            }
        }


        public ResearchTeam(string resTopic, string organization, int regNumber, TimeFrame timeFrame, List<Paper> publications) : base(organization, regNumber)
        {
            ResearchTopic = resTopic;
            DurationOfResearch = timeFrame;
            ListOfPublications = publications;
            ListOfMembers = new List<Person>();
        }


        public ResearchTeam() : this("default", "default", 1, new TimeFrame(), new List<Paper>())
        {
            ListOfMembers = new List<Person>();
        }


        public bool this[TimeFrame time]
        {
            get
            {
                return time == DurationOfResearch;
            }
        }

       public T DeepCopy<T>(object obj) where T : class
        {
            if (obj is T serialisedObject)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                    try
                    {
                        serializer.WriteObject(ms, serialisedObject);
                        ms.Position = 0;
                        return serializer.ReadObject(ms) as T;
                    }
                    catch (InvalidDataContractException e)
                    {                        
                        Console.WriteLine(e.Message);
                    }
                    catch (SerializationException e)
                    {                        
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        ms.Close();
                    }
                }
                
            }
            throw new ArgumentException($"I cannot convert { nameof(serialisedObject) } to ResearchTeam");
        }

        public static bool Load(string filename, ResearchTeam researchTeam)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";

            try
            {
                using (FileStream fs = File.OpenRead(fileLocation + filename + fileFormat))
                {
                    byte[] array = new byte[fs.Length];
                    fs.Read(array, 0, array.Length);
                    string json = Encoding.Default.GetString(array);

                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                    ResearchTeam deserializedTeam = new ResearchTeam();
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedTeam.GetType());
                    deserializedTeam = ser.ReadObject(ms) as ResearchTeam;

                    researchTeam.ResearchTopic = deserializedTeam.ResearchTopic;
                    researchTeam.Name = deserializedTeam.Name;
                    researchTeam.DurationOfResearch = deserializedTeam.DurationOfResearch;
                    researchTeam.RegisterNumber = deserializedTeam.RegisterNumber;
                    researchTeam.ListOfPublications = deserializedTeam.ListOfPublications;
                    researchTeam.ListOfMembers = deserializedTeam.ListOfMembers;

                    ms.Close();
                    fs.Close();
                    return true;
                }               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public static bool Save(string filename, ResearchTeam saveResearch)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";

            ResearchTeam research = new ResearchTeam(saveResearch.ResearchTopic, saveResearch.Organization, saveResearch.RegisterNumber,
                saveResearch.DurationOfResearch, saveResearch.ListOfPublications);
            research.ListOfMembers = saveResearch.ListOfMembers;

            MemoryStream ms = new MemoryStream();

            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ResearchTeam));
                ser.WriteObject(ms, research);
                byte[] json = ms.ToArray();

                var objectToJson = Encoding.UTF8.GetString(json, 0, json.Length);
                FileStream fs = new FileStream(fileLocation + filename + fileFormat, FileMode.OpenOrCreate);
                fs.SetLength(0);

                byte[] arr = Encoding.Default.GetBytes(objectToJson);
                fs.Write(arr, 0, arr.Length);
                fs.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            { 
                ms.Close(); 
            }
            return false;
        }



        public bool Save(string filename)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";
        
            ResearchTeam researchTeam = new ResearchTeam(ResearchTopic, Organization, RegisterNumber, DurationOfResearch, ListOfPublications);
            researchTeam.ListOfMembers = ListOfMembers;
            
            MemoryStream ms = new MemoryStream();
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ResearchTeam));
                ser.WriteObject(ms, researchTeam);
                byte[] json = ms.ToArray();
                var objToJson = Encoding.UTF8.GetString(json, 0, json.Length);
                FileStream fs = new FileStream(fileLocation + filename + fileFormat, FileMode.OpenOrCreate);
                fs.SetLength(0);
                byte[] arr = Encoding.Default.GetBytes(objToJson);
                fs.Write(arr, 0, arr.Length);
                fs.Close();
                return true;    
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                ms.Close();
            }
            return false;
        }

        public bool Load(string filename)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";

            try
            {
                using (FileStream fs = File.OpenRead(fileLocation + filename + fileFormat))
                {
                    byte[] arr = new byte[fs.Length];
                    fs.Read(arr, 0, arr.Length);
                    string json = Encoding.Default.GetString(arr);

                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                    ResearchTeam deserializedTeam = new ResearchTeam();
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedTeam.GetType());
                    deserializedTeam = ser.ReadObject(ms) as ResearchTeam;

                    ResearchTopic = deserializedTeam.ResearchTopic;
                    Name = deserializedTeam.Name;
                    DurationOfResearch = deserializedTeam.DurationOfResearch;
                    RegisterNumber = deserializedTeam.RegisterNumber;
                    ListOfMembers = deserializedTeam.ListOfMembers;
                    ListOfPublications = deserializedTeam.ListOfPublications;

                    ms.Close();
                    fs.Close();

                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }


        public bool AddPaperFromConsole()
        {
            Console.WriteLine("Input the data for Paper object like the next format: \n" + 
                "name of publication;the data of publication;Author: firstname;lastname;date of birth(Format: YYYY:MM:DD)\n" + 
                "For instance: Discovery;2015-04-19;Tom;Carter;1999-09-11");

            Person person = new Person();
            Paper paper = new Paper();

            var inputText = Console.ReadLine();
            string[] splitText = new string[] { "" };

            if(inputText != null)
            {
                splitText = inputText.Split(';');
            }

            try
            {
                paper.Publication = splitText[0];
                var yearOfPublishing = Convert.ToInt32(splitText[1].Split('-')[0]);
                var monthOfPublishing = Convert.ToInt32(splitText[1].Split('-')[1]);
                var dayOfPublishing = Convert.ToInt32(splitText[1].Split('-')[2]);
                paper.DateTime = new DateTime(yearOfPublishing, monthOfPublishing, dayOfPublishing);

                person.FirstName = splitText[2];
                person.LastName = splitText[3];
                var yearOfBirth = Convert.ToInt32(splitText[4].Split('-')[0]);
                var monthOfBirth = Convert.ToInt32(splitText[4].Split('-')[1]);
                var dayOfBirth = Convert.ToInt32(splitText[4].Split('-')[2]);

                person.DateOfBirth = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);
                paper.Person = person;
                ListOfPublications.Add(paper);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }



        public void AddPapers(params Paper[] papers)
        {
            ListOfPublications.AddRange(papers);
        }
        public void AddMembers(params Person[] members)
        {
            ListOfMembers.AddRange(members);
        }


        protected bool Equals(ResearchTeam research)
        {

            return base.Equals(research) && Organization.Equals(research.Organization) && DurationOfResearch.Equals(research.DurationOfResearch);
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((ResearchTeam)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ ResearchTopic.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)DurationOfResearch;
                hashCode = (hashCode * 397) ^ (ListOfMembers != null ? ListOfMembers.GetHashCode() : 0);
                hashCode = (hashCode * 397) & (ListOfPublications != null ? ListOfPublications.GetHashCode() : 0);
                return hashCode;
            }
        }

        public string Name { get; set; }
        public new object DeepCopy()
        {
            var selected = (ResearchTeam)MemberwiseClone();
            selected.ListOfMembers = new List<Person>();
            selected.ListOfPublications = new List<Paper>();
            foreach (Person person in ListOfMembers)
                selected.ListOfMembers.Add(person);
            foreach (Paper paper in ListOfPublications)
                selected.ListOfPublications.Add(paper);
            return selected;
        }



        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            return x.Organization.CompareTo(y.Organization);
        }


        public IEnumerable<Person> MembersWithoutAnyPublications()
        {
            if (ListOfPublications.Count < 0)
                yield break;
            foreach (Paper paper in ListOfPublications)
            {
                if (paper.Publication == null || paper.DateTime == default)
                {
                    yield return paper.Person;
                }
            }


        }

        public IEnumerable<Paper> GetPublishInRecentYears(int year)
        {
            if (ListOfPublications.Count < 0)
                yield break;
            foreach (Paper paper in ListOfPublications)
            {
                if (DateTime.Now.Year - paper.DateTime.Year < year)
                    yield return paper;
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }


        public virtual string ToShortString()
        {
            return $"Organization: {Organization} \t Topic: {ResearchTopic} \t Register number: {RegisterNumber} \t TimeFrame: {DurationOfResearch} ";
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(ToShortString());
            builder.AppendLine(base.ToString());
            builder.AppendLine($"Topic: {ResearchTopic}");
            builder.AppendLine($"Duration: {DurationOfResearch}");
            builder.AppendLine("Members: ");
            if (ListOfMembers != null)
                foreach (Person member in ListOfMembers)
                    builder.AppendLine(member.ToString());
            builder.AppendLine("Publications: ");
            if (ListOfPublications != null)
                foreach (Paper paper in ListOfPublications)
                    builder.AppendLine(paper.ToString());
            return builder.ToString();
        }


    }
}
