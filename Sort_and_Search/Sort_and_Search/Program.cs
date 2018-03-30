using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_and_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

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
            //bubbleSort(array, array.Length); bubblesort works
            //insertionSort(array); insertion sort works
        }

        //Function for searching        
        /// <summary>
        /// Function for the Bubble Sort algorithm. It will output the results at the end also.
        /// </summary>
        /// <param name="array">Takes in an array (to be defined by the user) for sorting.</param>
        /// <param name="length">This variable is the length of the array given in the other variable.</param>
        public static void bubbleSort(int[] array, int length)
        {
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1 - i; j++)
                {
                    if (array[j + 1] < array[j])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            //loop to show the numbers in order
            foreach (int number in array)
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
        public static void MergeSort(int[] input, int startIndex, int endIndex)
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
        public static void Merge(int[] input, int left, int mid, int right)
        {
            int[] temp = new int[input.Length];
            int i, leftEnd, lengthOfInput, tmpPos;
            leftEnd = mid - 1;
            tmpPos = left;
            lengthOfInput = right - left + 1;

            //Selecting values from given sides and placing them in a temp array
            while ((left <= leftEnd) && (mid <= right))
            {
                if (input[left] <= input[mid])
                {
                    temp[tmpPos++] = input[left++];
                }
                else
                {
                    temp[tmpPos++] = input[mid++];
                }
            }
            //place the element from left sorted array into the temp
            while (left <= leftEnd)
            {
                temp[tmpPos++] = input[left++];
            }

            //place the element from right sorted array into temp
            while (mid <= right)
            {
                temp[tmpPos++] = input[mid++];
            }

            //placing temp array to input
            for (i = 0; i < lengthOfInput; i++)
            {
                input[right] = temp[right];
                right--;
            }
        }
        /// <summary>
        /// Function to perform the Quick Sort algorithm.
        /// </summary>
        /// <param name="A">This parameter takes in an array to sort</param>
        /// <param name="left">Parameter to take in a variable from the left</param>
        /// <param name="right">Parameter to take in a variable at the right</param>
        public static void quickSort(int[] A, int left, int right)
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
        private static int partition(int[] A, int left, int right)
        {
            if (left > right) { return -1; }
            int end = left;
            int pivot = A[right];
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
        private static void swap(int[] A, int left, int right)
        {
            int tmp = A[left];
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
        public static int binarySearch(int[] inputArray, int key)
        {
            //min and max are the variable at the start end of the given array
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
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
        //into ascending order with relevant algorithm. 
        //now take in a user defined variable for searching in said array and show items location within the array
        //or else show an error.
        //(future) if value cannot be found then show the two closest values and locations in array
        //(future) take in two files and merge these together before performing the above files
    }
}