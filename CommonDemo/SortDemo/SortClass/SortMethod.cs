using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortDemo.SortClass
{
    /// <summary>
    /// 排序
    /// </summary>
    public static class SortMethod
    {
        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="lst_Sort"></param>
        public static void InsertionSortMethod(List<int> lst_Sort)
        {
            int i, j;
            int temp;
            for (i = 1; i <lst_Sort.Count ; i++)
            {
                temp = lst_Sort[i];
                for (j = i; j >0 && lst_Sort[j -1] < temp; j--)
                {
                    lst_Sort[j] = lst_Sort[j -1];
                }
                lst_Sort[j] = temp;
            }
        }

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="lst_Sort"></param>
        public static void BubbleSortMethod(List<int> lst_Sort)
        {
            int i, j;
            bool isChanged = false;//是否有交换
            for (i = 0; i < lst_Sort.Count-1; i++)
            {
                isChanged = false;
                for (j = lst_Sort.Count-1; j > i; j--)
                {
                    if (lst_Sort[j]> lst_Sort[j-1])
                    {
                        lst_Sort[j] = lst_Sort[j] + lst_Sort[j - 1];
                        lst_Sort[j -1] = lst_Sort[j] - lst_Sort[j - 1];
                        lst_Sort[j] = lst_Sort[j]- lst_Sort[j - 1];
                        isChanged = true;
                    }
                }
                //若没有交换则说明已经有序 退出
                if (!isChanged)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 希尔排序
        /// </summary>
        /// <param name="lst_Sort"></param>
        public static void ShellSortMethod(List<int> lst_Sort)
        {
            int i, j;
            int temp;
            for (int increment = lst_Sort.Count/2; increment >0; increment/=2)
            {
                for (i = 0; i < lst_Sort.Count; i++)
                {
                    temp = lst_Sort[i];
                    for (j=i; j < lst_Sort.Count; j+=increment)
                    {
                        if (j+increment< lst_Sort.Count&&lst_Sort[j+increment]<temp)
                        {
                            lst_Sort[j] = lst_Sort[j+increment];
                        }
                        else
                        {
                            break;
                        }
                    }
                    lst_Sort[j] = temp;
                }
            }
        }
    }
}
