using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        /*
        Everything here will be based of from the green side pointing towards you and the white on top, and 
        red right, yellow bottom, orange left.
                |w center|
        o center|g center|r center|b center|
                |y center|
        */
        //View it as the folded mesh looks like
        string[][,] cube =
        [
            new string[3, 3]
                {{"y","y","g"}, //White center
                 {"g","w","r"},
                 {"o","r","y"}},
            new string[3, 3]
                {{"b","o","g"}, //Orange center
                 {"y","o","y"},
                 {"r","g","w"}},
            new string[3, 3]
                {{"w","w","b"}, //Green center
                 {"o","g","o"},
                 {"r","r","r"}},
            new string[3, 3]
                {{"r","b","o"}, //Red center
                 {"b","r","w"},
                 {"y","y","w"}},
            new string[3, 3]
                {{"y","r","o"}, //Blue center
                 {"b","b","b"},
                 {"o","w","b"}},
            new string[3, 3]
                {{"g","g","g"}, //Yellow center (White->Green->Yellow)
                 {"w","y","g"},
                 {"w","o","b"}},
        ];
        CubeAlgos.Print(cube);

    }
}
class CubeAlgos
{
    public static void Rotate2dArray(string[,] square)
    {
        //rotate corners
        string tempCorner1 = square[0,0];
        string tempCorner2 = square[2,2];
        square[0,0] = square[2,0];
        square[2,2] = square[0,2];
        square[0,2] = tempCorner1;
        square[2,0] = tempCorner2;
        
        //rotate edges
        string tempEdge1 = square[0,1];
        string tempEdge2 = square[2,1];
        square[0,1] = square[1,0];
        square[2,1] = square[1,2];
        square[1,0] = tempEdge1;
        square[1,2] = tempEdge2;
        
    }
    public static void Print(string[][,] cube)
    {
        //prints top part with white center
        for (int i = 0; i < 3; i++)
        {
            Console.Write("      |");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(cube[0][i,j]);
                if (j!=2)
                {
                    Console.Write(",");
                }
                else
                {
                    Console.Write("|");
                }
            }
            Console.WriteLine();
        }
        //prints 2nd layer with left blue center, middle white center, right green center, away yellow center
        Console.WriteLine("-------------------------");
        for (int i = 0; i < 3; i++)
        {
            Console.Write("|");
            for (int j = 1; j <= 4; j++)
                for (int k = 0; k < 3; k++)
                {
                    Console.Write(cube[j][i,k]);
                    if (k!=2)
                    {
                        Console.Write(",");
                    }
                    else
                    {
                        Console.Write("|");
                    }
                }
            Console.WriteLine();
        }

        //Print Yellow Center
        Console.WriteLine("-------------------------");
        for (int i = 0; i < 3; i++)
        {
            Console.Write("      |");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(cube[5][i,j]);
                if (j!=2)
                {
                    Console.Write(",");
                }
                else
                {
                    Console.Write("|");
                }
            }
            Console.WriteLine();
        }
        
    }
}

