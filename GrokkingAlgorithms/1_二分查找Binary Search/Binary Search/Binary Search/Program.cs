using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search
{
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			int[] list = new int[] { 1, 2, 6, 7, 9, 11, 23, 55, 78, 111, 180, 299, 400, 800, 1200, 9999, 120000, 4000000, 102410240 };
			int times,times1,times2 = 0;
			int target = 6;
			Search(list, list[0], out times1);
			Search(list, list[list.Length-1], out times2);
			var result = Search(list, 2, out times);

			Console.WriteLine("查找数组Count：{0},最坏情况：max ({1},{2})", list.Length, times1, times2);
			Console.WriteLine("查找目标：{0}，其索引值：{1},查找次数：{2}", target, result, times);

			#region Test Wait
			Console.Read();
			#endregion
		}

		/// <summary>
		/// 二分查找有序数列，返回最终目标与次数
		/// return -1是没找到，其他是对应的Index
		/// times 是次数
		/// </summary>
		public static int Search(int[] list,int target,out int times)
		{
			times = 0;

			var low = 0;
			var high = list.Length - 1;
			int mid;

			while (low <= high)
			{
				times++;
				mid = (low + high) / 2;

				if (target == list[mid])
				{
					return mid;
				}
				else if (target > list[mid])
				{
					low = mid + 1;
				}
				else
				{
					high = mid - 1;
				}
			}

			return -1;
		}
	}
}
