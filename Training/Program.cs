using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = { 10, 2, 5, 7, 3, 12, 6 }; // 2 5 7 3 10 6 12     2 5 3 7 6 10 12     2 3 5 6 7 10 12

            Console.WriteLine("Default arr: ");
            ShowArr(arr);

            int[] sortedArr = Mergesort(arr, 0, arr.Length - 1);

            Console.WriteLine("Sorted arr: ");
            ShowArr(sortedArr);
        }

        public static void ShowArr(int[] arr)
        {
            foreach(var item in arr)
                Console.Write($"{item} ");
            Console.WriteLine("\n");
        }

        /// <summary>
        /// Легкий в написании, но самый затратный по TC
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] Bubblesort(int[] arr) //TC: O(n^2)  SC:O(1)  timecomplexity spacecomplexity
        {
            for(int j = 0; j < arr.Length-1; j++)
            {
                for (int i = 0; i < arr.Length-j-1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }
                }
            }
            return arr;
        }

        /// <summary>
        /// Применимо, когда нам важны TC и SC. Используется рекурсия, поэтому в некоторых языках может произойти ошибка глубины рекурсии
        /// </summary>
        /// <param name="arr">Target Array</param>
        /// <param name="low">The greatest element</param>
        /// <param name="high">The rightmost element</param>
        /// <returns></returns>
        public static int[] Quicksort(int[] arr, int low, int high) // TC: the worst: O(n^2) avg: O(n*log(n))  SC: O(log(n)) 
        {
            if(low < high)
            {
                int pi = Partition(arr, low, high);
                Quicksort(arr, low, pi - 1);
                Quicksort(arr, pi + 1, high);
            }
            return arr;
        }
        public static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for(int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;

                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }

        /// <summary>
        /// Постоянные значения TC и SC
        /// </summary>
        /// <param name="arr">Target Array</param>
        /// <param name="l">Left border of array</param>
        /// <param name="r">Rigth border of array</param>
        /// <returns></returns>
        public static int[] Mergesort(int[] arr, int l, int r) // TC: O(n*log(n)) SC: O(n)
        {
            if(l < r)
            {
                int m = (l + r) / 2;
                Mergesort(arr, l, m);
                Mergesort(arr, m + 1, r);
                Merge(arr, l, m, r);
            }
            return arr;
        }
        /// <summary>
        /// Функция для слияния subArrays
        /// </summary>
        /// <param name="arr">Target Array</param>
        /// <param name="l">Left border of target arr</param>
        /// <param name="m">The middle of target arr</param>
        /// <param name="r">Right border of target arr</param>
        public static void Merge(int[] arr, int l, int m, int r)
        {
            int[] subArr1 = new int[m - l + 1];
            int[] subArr2 = new int[r - m];

            //Заполнение subarrays
            for(int z = 0; z < subArr1.Length; z++)
            {
                subArr1[z] = arr[l + z];
            }
            for(int z = 0; z < subArr2.Length; z++)
            {
                subArr2[z] = arr[m + z +1];
            }

            ///Создаем поинтеры для наших subarrays
            ///Create three pointers i, j and k
            ///i maintains current index of subArr1, starting at 1
            ///j maintains current index of subArr2, starting at 1
            ///k maintains the current index of arr[l..m], starting at l.
            int i, j, k;
            i = 0;
            j = 0;
            k = l;

            //Пробегаемся до конца каждого subArr и соответственно заполняем A[l..r]
            while(i < subArr1.Length && j < subArr2.Length)
            {
                if (subArr1[i] <= subArr2[j])
                {
                    arr[k] = subArr1[i];
                    i++;
                }
                else
                {
                    arr[k] = subArr2[j];
                    j++;
                }
                k++;
            }

            //Заполняем оставшиеся элементы
            while(i < subArr1.Length)
            {
                arr[k] = subArr1[i];
                k++;
                i++;
            }
            while(j < subArr2.Length)
            {
                k++;
                j++;
            }
        }

    }
}
