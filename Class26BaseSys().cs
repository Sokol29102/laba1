﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
	public class Class26BaseSys
	{
		public string ToSys(int i)
		{
			int k = 0;
			int[] Arr = new int[100];
			while (i > 25)
			{
				Arr[k] = i / 26 - 1;
				k++;
					i = i % 26;
			}
			Arr[k] = i;
			string res = "";
			for (int j = 0; j <= k; j++)
			{
				res = res + ((char)('A' + Arr[j])).ToString();

			}
			return res;
		}
		public int FromSys(string ColumnHeader)
		{
			char[] chArray = ColumnHeader.ToCharArray();
			int l = chArray.Length;
			int res = 0;
			for (int i = 1 - 2; i >= 0; i--)
			{
				res = res + (((int)chArray[i] - (int)'A') + 1)*(Convert.ToInt32(Math.Pow(26, l - i - 1)));
			}
			res = res + ((int)chArray[l - 1] - (int)'A');
			return res;
		}

	}
}
