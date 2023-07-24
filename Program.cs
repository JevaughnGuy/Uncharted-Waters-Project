using System;
using System.Data;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace UnchartedWatersArrayProject {
    internal class Program {
        static void Main(string[] args) {
            int[,,] satDataArray; //empty three dimensional array 

            satDataArray = GetSatelliteData();
             Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Surface Level SubPopulation is  --- {OceanPopulous(satDataArray, 0)} \n");

            Console.WriteLine($"UnderWater Level SubPopulation is  --- {OceanPopulous(satDataArray, 1)}\n");

            Console.WriteLine($"DeepWater Level SubPopulation is  --- {OceanPopulous(satDataArray, 2)}\n");

            Console.WriteLine($"US Sub / Enemy Sub Ratio is --- {TotalSunkenRatio(satDataArray)}\n");

            Console.WriteLine($"Attack on Surface {AttackorNot(satDataArray, 0)}\n");

            Console.WriteLine($"Attack on Underwater {AttackorNot(satDataArray, 1)}\n");

            Console.WriteLine($"Attack on Deep {AttackorNot(satDataArray, 2)}\n");


            PrintLevels(satDataArray);







        }//end main 
        // in " .GetLength(0)"- represents the first dimension ".GetLength(1)" - represents the second dimension ".GetLength(2)" - represents the third dimension
        static int[,,] GetSatelliteData() { // this gives me the random satellite data 
            Random rand = new Random();
            int[,,] data = new int[10, 10, 3];


            for (int z = 0; z < data.GetLength(2); z++) {
                for (int y = 0; y < data.GetLength(1); y++) {
                    for (int x = 0; x < data.GetLength(0); x++) {
                        if (rand.Next(0, 101) < 25) {    //One and 4 chance of this line being less than 25 if it is than line 47 will determine if its more than 25 a 0 will be placed
                            data[x, y, z] = rand.Next(1, 3); //if its not 

                        }//end of if 
                    }//end of for        
                }//end of for 
            }//end of for 

            return data;
        }//end of func 

        /* static int SubmarinePopulous(int[] data) {

         }*/

        static double OceanPopulous(int[,,] array , int layer) {  //This function gives me my submarine percentage wether it was the enemy sub or US sub its both on this function 
            int subPopulationTotal = 0;
            double subPercentageDub = 0;

            for (int y = 0; y < array.GetLength(1); y++)
                for (int x = 0; x < array.GetLength(0); x++) {
                    int value = array[x, y, layer];
                    if (value > 0) {
                        subPopulationTotal++;
                    }
                }
            subPercentageDub = (double)subPopulationTotal / 100;
            return subPercentageDub;
        }// end Func

        static void OceanLevelPrint(int[,,] satDataArray, int layer) {   /*in this function he wants me to pass the third number in the array that I call layer into this print function
        in order to print the layers of the ocean*/

            for (int y = 0; y < satDataArray.GetLength(1); y++) {
                for (int x = 0; x < satDataArray.GetLength(0); x++) {
                    Console.Write(satDataArray[x, y, layer] + " ");
                }//end for
                Console.WriteLine("\n");
            }//end for 

        }// end print 

        static void PrintLevels(int[,,] satDataArray) { /* here he wants me to make a function id be able to call to print all three but this shit doesnt make sense */

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nSurface\n");
            OceanLevelPrint(satDataArray, 0);
            Console.ForegroundColor= ConsoleColor.Gray;
            Console.WriteLine("UnderWater\n");
            OceanLevelPrint(satDataArray, 1);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("DeepWater\n");
            OceanLevelPrint(satDataArray, 2);
        }//end of printlevels function 
        static double SunkenRatio(int[,,] satDataArray, int layer) {
            int usSub = 0;
            int enemySub = 0;
            double ratio = 0.0;

            for (int y = 0; y < satDataArray.GetLength(1); y++) {
                for (int x = 0; x < satDataArray.GetLength(0); x++) {
                    int value = satDataArray[x, y, layer];
                    if (value == 1) {
                        usSub++;
                    } else if (value == 2) {
                        enemySub++;
                    }
                }
            }
                
            ratio = (double)usSub / enemySub;

            return ratio;

        }

        static double TotalSunkenRatio(int[,,] satDataArray ) {
           double allLevelRatio = 0.0;
            double allLevelRatio2 = 0.0;

            allLevelRatio= SunkenRatio(satDataArray, 0) + SunkenRatio(satDataArray, 1) + SunkenRatio(satDataArray, 2);
            allLevelRatio2 = allLevelRatio / 3;
            return allLevelRatio2 ;
        }

        static bool AttackorNot(int[,,] satDataArray, int layer) {
            int usSub = 0;
            int enemySub = 0;
              for (int y = 0; y < satDataArray.GetLength(1); y++) {
                for (int x = 0; x < satDataArray.GetLength(0); x++) {
                    int value = satDataArray[x, y, layer];
                    if (value == 1) {
                        usSub++;
                    } else if (value == 2) {
                        enemySub++;
                    }//end if
                }// end for
            }//end for 
            if(enemySub > usSub) {
                return false;
            }//end if 
            else { 
            return true;

            }//end else if
        }// end of func

    }//end of class
}
    

       