using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_and_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                bool option_searchable = true;
                string fileType, fileRange;
                string filePath = "";

                Console.Write("Welcome to CMP1124M Algorithms Complexity: Assessment 2.\r\nPlease type number referring to the file you want to use:");
                Console.WriteLine("----------------------");
                Console.Write("[1] - Low\r\n[2] - High\r\n[3] - Open\r\n[4] - Close\r\n[5] - Change\r\n[6] - Exit\r\n");
                fileType = Console.ReadLine();
                //Depending on the type of file chosen will bring up the files within said range
                Console.WriteLine("----------------------");
                Console.Write("[1] - 128\r\n[2] - 256\r\n[3] - 1024\r\n[4] - Exit\r\n");
                fileRange = Console.ReadLine();

                if (fileType == "1" && fileRange == "1")
                {
                    filePath = "Low_128";
                } else if (fileType == "1" && fileRange == "2")
                {
                    filePath = "Low_256";
                } else if (fileType == "1" && fileRange == "3")
                {
                    filePath = "Low_1024";
                } else if (fileType == "2" && fileRange == "1")
                {
                    filePath = "High_128";
                } else if (fileType == "2" && fileRange == "2")
                {
                    filePath = "High_256";
                } else if (fileType == "2" && fileRange == "3")
                {
                    filePath = "High_1024";
                } else if (fileType == "3" && fileRange == "1")
                {
                    filePath = "Open_128";
                } else if (fileType == "3" && fileRange == "2")
                {
                    filePath = "Open_256";
                } else if (fileType == "3" && fileRange == "3")
                {
                    filePath = "Open_1024";
                } else if (fileType == "4" && fileRange == "1")
                {
                    filePath = "Close_128";
                } else if (fileType == "4" && fileRange == "2")
                {
                    filePath = "Close_256";
                } else if (fileType == "4" && fileRange == "3")
                {
                    filePath = "Close_1024";
                } else if (fileType == "5" && fileRange == "1")
                {
                    filePath = "Change_128";
                } else if (fileType == "5" && fileRange == "2")
                {
                    filePath = "Change_256";
                } else if (fileType == "5" && fileRange == "3")
                {
                    filePath = "Change_1024";
                } else
                {
                    Console.WriteLine("Option not available...");
                    option_searchable = false;
                }

                if (option_searchable == true)
                {

                    //Now we will search for the number given by the user
                    Console.WriteLine("-------------------\r\nWhat number would you like to search?");
                    decimal numberSearch = Convert.ToDecimal(Console.ReadLine());
                    findValue(filePath, fileRange, numberSearch);
                    //After completing the programs iteration, we will check if the user wants to continue or not.
                    Console.Write("-------------------\r\nPress 1 to continue or 2 to exit...");
                    string choice = Console.ReadLine();
                    if (choice == "2")
                    {
                        Console.WriteLine("Program is now closing...");
                        Console.ReadLine();
                        break;
                    }
                } else
                {
                    //Due to option not being searchable, we check if the user wants to try again or exit
                    Console.Write("-------------------\r\nPress 1 to continue or 2 to exit...");
                    string choice = Console.ReadLine();
                    if (choice == "2")
                    {
                        Console.WriteLine("Program is now closing...");
                        Console.ReadLine();
                        break;
                    }
                }
            }
            //Console.WriteLine(linSearch(array, 4)); Linear Search works

            //Console.WriteLine(binarySearch(array, 3)); Binary Search Works

            /*quickSort(array, 0, array.Length-1);
            foreach (int num in array)
            {
                Console.Write(num + ", ");
            }*/
            /*MergeSort(array, 0, array.Length - 1);
            foreach(int num in array)
            {
                Console.Write(num + ", ");
            }*/
            //bubbleSort(myInts, myInts.Length); bubblesort works
            //insertionSort(array); insertion sort works
        }

        //Function for searching        
        /// <summary>
        /// Function for the Bubble Sort algorithm. It will output the results at the end also.
        /// </summary>
        /// <param name="array">Takes in an array (to be defined by the user) for sorting.</param>
        /// <param name="length">This variable is the length of the array given in the other variable.</param>
        public static void bubbleSort(decimal[] array, decimal length)
        {
            for (decimal i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1 - i; j++)
                {
                    if (array[j + 1] < array[j])
                    {
                        decimal temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            //loop to show the numbers in order
            foreach (decimal number in array)
            {
                Console.WriteLine(number);
            }
        }
        /// <summary>
        /// This is a function for the Insertion Sorting Algorithm.
        /// </summary>
        /// <param name="array">This parameter takes in a variable called 'array'. This is the array specified in the main function.</param>
        public static void insertionSort(int[] array)
        {
            int length = array.Length;

            for (int i = 1; i < length; i++)
            {
                int j = i;
                while ((j > 0) && (array[j] < array[j - 1]))
                {
                    int k = j - 1;
                    int temp = array[k];
                    array[k] = array[j];
                    array[j] = temp;

                    j--;
                }
            }
            //to loop and show each number now sorted
            foreach (int num in array)
            {
                Console.WriteLine(num);
            }
        }
        /// <summary>
        /// Function for sorting the given array, utilising the merge function below as part of the algorithm
        /// </summary>
        /// <param name="input">Parameter taking in the integer array</param>
        /// <param name="startIndex">Parameter for the starting point of the search</param>
        /// <param name="endIndex">Parameter for the ending point of the search</param>
        public static void MergeSort(decimal[] input, int startIndex, int endIndex)
        {
            int mid;
            if (endIndex > startIndex)
            {
                mid = (endIndex + startIndex) / 2;
                MergeSort(input, startIndex, mid);
                MergeSort(input, (mid + 1), endIndex);
                Merge(input, startIndex, (mid + 1), endIndex);
            }
        }
        /// <summary>
        /// Function for merging the two sorted arrays into one big array
        /// </summary>
        /// <param name="input">Parameter is the array that is given</param>
        /// <param name="left">Left value</param>
        /// <param name="mid">Middle value</param>
        /// <param name="right">Right value</param>
        public static void Merge(decimal[] input, int left, int mid, int right)
        {
            decimal[] temp = new decimal[input.Length];
            int i, leftEnd, lengthOfInput, tmpPos;
            leftEnd = mid - 1;
            tmpPos = left;
            lengthOfInput = right - left + 1;

            //Selecting values from given sides and placing them in a temp array
        }
        public static void quickSort(decimal[] A, int left, int right)
        {
            if (left > right || left < 0 || right < 0) { return; }
            int index = partition(A, left, right);
            if (index != -1)
            {
                quickSort(A, left, index - 1);
                quickSort(A, index + 1, right);
            }
        }
        //Function for performing the pivot
        private static int partition(decimal[] A, int left, int right)
        {
            if (left > right) { return -1; }
            int end = left;
            decimal pivot = A[right];
            for (int i = left; i < right; i++)
            {
                if (A[i] < pivot)
                {
                    swap(A, i, end);
                    end++;
                }
            }
            swap(A, end, right);
            return end;
        }
        //Function to swap ints around within specified array
        private static void swap(decimal[] A, int left, int right)
        {
            decimal tmp = A[left];
            A[left] = A[right];
            A[right] = tmp;
        }

        //Function for searching
        /// <summary>
        /// Function for the Binary Search algorithm
        /// </summary>
        /// <param name="inputArray">Parameter takes an array to search over</param>
        /// <param name="key">Parameter takes the value to peform the search on</param>
        /// <returns></returns>
        public static int binarySearch(decimal[] inputArray, decimal key)
        {
            //min and max are the variable at the start end of the given array
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return mid;
                } else if (key < inputArray[mid])
                {
                    max = mid - 1;
                } else
                {
                    min = mid + 1;
                }
            }
            return 100;
        }
        //Function for the Linear Search Algorithm. Taking in an array and value to search for within said array
        public static int linSearch<T>(T[] v, T target)
        {
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i].Equals(target)) return i;
            }
            return -1;

        }

        //function for grabbing the text file and inputting this into an array and then arrange 
        public static void findValue(string fileName, string sortTypeSelected, decimal numberSearch)//, string searchTypeSelected)
        {
            //read the file to a string array
            string[] lines = File.ReadAllLines(@"..\Bank_Data\" + fileName + ".txt");
            //Now convert to numbers for the algorithms above
            decimal[] myInts = lines.Select(n => Convert.ToDecimal(n)).ToArray();


            if (sortTypeSelected == "1")
            {
                bubbleSort(myInts, myInts.Length);
                decimal numberSearched = binarySearch(myInts, numberSearch);
                Console.WriteLine("Your number was {0}!", numberSearched);
            } else if (sortTypeSelected == "2")
            {
                quickSort(myInts, 0, myInts.Length - 1);
                decimal numberSearched = binarySearch(myInts, numberSearch);
                Console.WriteLine("Your number was {0}!", numberSearched);
            } else if (sortTypeSelected == "3")
            {
                MergeSort(myInts, 0, myInts.Length - 1);
                decimal numberSearched = binarySearch(myInts, numberSearch);
                Console.WriteLine("Your number was {0}!", numberSearched);
            } else
            {
                Console.Write("No sorry");
            }


        }
        //into ascending order with relevant algorithm. 
        //now take in a user defined variable for searching in said array and show items location within the array
        //or else show an error.
        //(future) if value cannot be found then show the two closest values and locations in array
        //(future) take in two files and merge these together before performing the above files
    }
}