using Microsoft.TeamFoundation.Work.WebApi;
using System;
using System.Diagnostics;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the count of rows and count of columns ( split it by ',' or whitespace ) =>");
            string[] informationFromUser = Console.ReadLine().Split(' ',',');
            if (informationFromUser == null || informationFromUser.Length < 2)
            { 
                return;
            }

            int.TryParse(informationFromUser[0], out int countOfRows);
            int.TryParse(informationFromUser[1], out int countOfColumns);


            Paper[] oneDimensionalArray = new Paper[countOfRows * countOfColumns];
            for(int i = 0; i < oneDimensionalArray.Length;i++)
            {
                oneDimensionalArray[i] = new Paper();
            }

            Paper[,] twoDimensionalArray = new Paper[countOfRows, countOfColumns];
            for(int i = 0; i < countOfRows;i++)
            {
                for(int j = 0; j < countOfColumns; j++)
                {
                    twoDimensionalArray[i, j] = new Paper();
                }
            }

            Paper[][] firstJaggedArray = new Paper[countOfRows][];
            for (int i = 0; i < countOfRows; i++)
            {
                firstJaggedArray[i] = new Paper[countOfColumns];
                for (int j = 0; j < countOfColumns; j++)
                {
                    firstJaggedArray[i][j] = new Paper();
                }
            }

            Paper[][] secondJaggedArray = new Paper[countOfRows][];
            for(int i = 0; i < countOfRows; i++)
            {
                secondJaggedArray[i] = new Paper[i];
                for(int j = 0; j < i;j++)
                {
                    secondJaggedArray[i][j] = new Paper();
                }
                //Console.WriteLine();
            }

            int startTime = Environment.TickCount;
            foreach(var element in oneDimensionalArray)
            {
                element.Publication = "Publication";
            }
            int endTime = Environment.TickCount;
            Console.WriteLine($"One dimensional array time : {startTime - endTime}");


            startTime = Environment.TickCount;
            foreach(var element in twoDimensionalArray)
            {
                element.Publication = "Publication";
            }
            endTime = Environment.TickCount;
            Console.WriteLine($"Two dimensional array time : {startTime - endTime}");

            
            startTime = Environment.TickCount;
            foreach(var arrOfElements in firstJaggedArray)
            {
                foreach(var element in arrOfElements)
                {
                    element.Publication = "Publication";
                }
            }
            endTime = Environment.TickCount;
            Console.WriteLine($"First Jagged Array time : {startTime - endTime}");


            startTime = Environment.TickCount;
            foreach (var arrOfElements in secondJaggedArray)
            {
                foreach (var element in arrOfElements)
                {
                    element.Publication = "Publication";
                }
            }
            endTime = Environment.TickCount;
            Console.WriteLine($"Second Jagged Array time : {startTime - endTime}");

                       
            Person person = new Person("nameTest", "lastnameTest", new DateTime(2005, 03, 04));
            Person person2 = new Person();
            Paper[] papersForAddPapers = new Paper[2]
            {
                new Paper("publicationTest", person,new DateTime(2010,10,10)),
                new Paper("publicationTest2", person,new DateTime(2011,11,11)),
            };
            Paper[] tempPaper = new Paper[3]
            {
                new Paper(),
                new Paper("testPublication",person2,new DateTime(2000,01,05)),
                new Paper("testPublication",person,new DateTime(2000,01,05))
            };
            ResearchTeam researchTeam = new ResearchTeam("TestTopic", "TestOrganization", 10, TimeFrame.Year, tempPaper);
            Console.WriteLine();


            Console.WriteLine(researchTeam.ToShortString());
            
            Console.WriteLine($"TimeFrame.Year: {researchTeam[TimeFrame.Year]} | TimeFrame.TwoYears: {researchTeam[TimeFrame.TwoYears]} TimeFrame.Long: {researchTeam[TimeFrame.Long]}");

            researchTeam.RegisterNumber = 7;
            researchTeam.AddPapers(papersForAddPapers);
            Console.WriteLine(researchTeam.ToString());


            /*Console.WriteLine("input the string: ");
            string str = Console.ReadLine();
            string[] check = str.Split('s');
            int nColumns = Convert.ToInt32(check[0]);
            int nRows = Convert.ToInt32(check[1]);

            Console.WriteLine($"nColumns: {nColumns}  nRows: {nRows}");
            
            ResearchTeam resTeam = new ResearchTeam("Ecology","National Geographic",312481, TimeFrame.Long);
            Console.WriteLine( resTeam.ToShortString());


            
            Console.WriteLine($"TimeFrame.Year: {resTeam[TimeFrame.Year]} | TimeFrame.TwoYears: {resTeam[TimeFrame.TwoYears]} TimeFrame.Long: {resTeam[TimeFrame.Long]}");

            int start, finish;

            Person testPerson = new Person("TestName", "TestLastName", new DateTime(10, 10, 10));

            Paper[] oneDimensionalArr = new Paper[nColumns * nRows];
            for(int i = 0;i < oneDimensionalArr.Length; i++)
            {
                oneDimensionalArr[i] = new Paper("testPublication", testPerson, new DateTime(5, 5, 5));
            }
            start = Environment.TickCount;
            for(int i = 0; i < oneDimensionalArr.Length; i++)
            {
                oneDimensionalArr[i].Publication = "Discovery";
            }
            finish = Environment.TickCount;
            Console.WriteLine($"One-dimensional array time: {Math.Abs(finish - start)}");

            
            Paper[,] multiDimensionalArray = new Paper[nColumns, nRows];
            //Paper[] tempArray = new Paper[nColumns * nRows];            
            for (int i = 0; i < nColumns; i++)
            {
                for (int j = 0; j < nRows; j++)
                {
                    multiDimensionalArray[i, j] = new Paper();
                }
               
            }
            start = Environment.TickCount;
            for (int i = 0; i < nColumns; i++)
            {
                for (int j = 0; j < nRows; j++)
                {
                    multiDimensionalArray[i, j].Publication = "Discovery";
                }
            }
            Console.WriteLine($"Multi-dimensional array time: {Math.Abs(finish - start)}");


            
            Paper[][] jaggedArr = new Paper[nColumns][];
            Paper[] arr ;
            int count = 1, sum = nColumns;
            for(int i = 0; i < jaggedArr.Length; i++)
            {
                arr = new Paper[count];
                for(int j = 0; j < arr.Length; j++)
                {
                    arr[j] = new Paper();
                    sum -= 1;
                    if(sum==0)                    
                        break;                    
                }
                jaggedArr[i] = arr;
                count++;

            }
            
            start = Environment.TickCount;
            for (int i = 0; i < jaggedArr.Length; i++)
            {
                for(int j = 0; j < jaggedArr[i].Length;j++)
                {
                    jaggedArr[i][j].Publication = "Discovery";
                }                
            }
            finish = Environment.TickCount;
            Console.WriteLine($"Jagged array time: {Math.Abs(finish - start) }" );


            Paper[][] jaggedArr2 = new Paper[nColumns][];
            for (int i = 0; i < jaggedArr2.Length; i++)
            {
                jaggedArr2[i] = new Paper[nRows];
                for (int j = 0; j < jaggedArr2[i].Length; j++)
                {
                    jaggedArr2[i][j] = new Paper();
                }
            }

            start = Environment.TickCount;
            for (int i = 0; i < jaggedArr2.Length; i++)
            {
                for (int j = 0; j < jaggedArr2[i].Length; j++)
                {
                    jaggedArr2[i][j].Publication = "Discovery2";
                }
            }
            finish = Environment.TickCount;
            Console.WriteLine($"Jagged array2 time : {Math.Abs(finish - start)}");

            resTeam.AddPapers(oneDimensionalArr);
            resTeam.AddPapers(oneDimensionalArr);
            Console.WriteLine(resTeam.ToString());
            Console.WriteLine($"The last publication: {resTeam.LastPublication}");
            */

        }
    }
}
