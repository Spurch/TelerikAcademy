/*
 * A program that prints a triangle composed of evenly distributed 
 * "c" signs. 
 */
using System;
class TriangleBuilder
{
    static void Main()
    {
        //This will give us the size of the matrix.
        //You can try with 10 or 20 - it will work just as good as with 8.
        int n = 8;
        //Here we declare a 2D array(NxN) that will hold the matrix.
        string[,] Matrix = new string[n, n];

        //We use 2 for-loops to insert a " " in every cell in the 2D array.
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Matrix[i, j] = " ";
            }
        }
        /*
         * We are going to use 2 additional variables to calculate the 
         * cells for the "c" signs in the 2D array/matrix.
         * We initialize them both with the position of the middle column
         * in the matrix.
        */
        int FirstFlag = n/2;
        int SecondFlag = n/2;

        //We are using a single loop to go through the
        //array and place the "c" signs in the appropriate cells.
        for (int i = 0; i < n; i++)
        {
            //We are going to need only the even rows.
            if (i % 2 == 0)
            {
                //We print the "c" for the current row.
                Matrix[i, FirstFlag] = "c";
                Matrix[i, SecondFlag] = "c";
                
                //This condition is for the bottom of the triangle.
                //We are using >= in order to handle cases where N is odd.
                if (i >= n-2)
                {
                    /*If we have reached the bottom of the triangle
                     * we use a for-loop to fill it with "c" signs.
                     * Note that we are iterating 'z' over 2 because
                     * we need to have space between the bottom "c".
                     */
                    for (int z = 0; z < n/2; z+=2)
                    {
                        Matrix[i, FirstFlag - z] = "c";
                        Matrix[i, SecondFlag + z] = "c";   
                    }
                }
            }
            else
            {
                //We move the flags to the left and to the right.
                //Note that when going down the rows each new pair of
                //"c" signs is equaly remote from the central column
                //(both left and right).
                FirstFlag = FirstFlag + 1;
                SecondFlag = SecondFlag - 1;
            }
        }

        //Two For-loops that we use to print the 2D array as matrix.
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                //Note: We use Console.Write because we are printing the rows.
                Console.Write(Matrix[i, j]);
            }
            //We call Console.WriteLine to move to the next row.
            Console.WriteLine();
        }
    }
}

