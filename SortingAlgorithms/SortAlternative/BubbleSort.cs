// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 01-03-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="BubbleSort.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Zeroit.Framework.Utilities.Search
{
    
    public static partial class SortingAlgorithm
	{
	    public static void BubbleSort(int[] array)
	    {
	        
	        int t;
	        
	        for (int p = 0; p <= array.Length - 2; p++)
	        {
	            for (int i = 0; i <= array.Length - 2; i++)
	            {
	                if (array[i] > array[i + 1])
	                {
	                    t = array[i + 1];
	                    array[i + 1] = array[i];
	                    array[i] = t;
	                }
	            }
	        }

	        
	    }

    }
}
