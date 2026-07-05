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
        //View it as the unfolded cube
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
                {{"g","g","g"}, //Yellow center
                 {"w","y","g"},
                 {"w","o","b"}},
        ];
        CubeAlgos.Print(cube);
        CubeAlgos.RotateRight(cube);
        Console.WriteLine("      -------");
        Console.WriteLine("      -------");
        CubeAlgos.Print(cube);
    }
}
class CubeAlgos
{
    //color constants
    private const int white = 0;
    private const int orange = 1;
    private const int green = 2;
    private const int red = 3;
    private const int blue = 4;
    private const int yellow = 5;

    public static void RotateFaceCW(string[,] square)
    {
        //rotate corners
        string tempCorner = square[0,0];
        square[0,0] = square[2,0];
        square[2,0] = square[2,2];
        square[2,2] = square[0,2];
        square[0,2] = tempCorner;
        
        //rotate edges
        string tempEdge = square[0,1];
        square[0,1] = square[1,0];
        square[1,0] = square[2,1];
        square[2,1] = square[1,2];
        square[1,2] = tempEdge;
    }
    public static void RotateFaceCCW(string[,] square)
    {
        //rotate corners
        string tempCorner = square[0,0];
        square[0,0] = square[0,2];
        square[0,2] = square[2,2];
        square[2,2] = square[2,0];
        square[2,0] = tempCorner;
        
        //rotate edges
        string tempEdge = square[0,1];
        square[0,1] = square[1,2];
        square[1,2] = square[2,1];
        square[2,1] = square[1,0];
        square[1,0] = tempEdge;
    }
    public static void RotateLayerCW(string face)
    {
        
    }
    public static void RotateRight(string[][,] cube)
    {
        //Red Face gets rotated
        RotateFaceCW(cube[red]);
        string topRight =    cube[green][0,2];
        string centerRight = cube[green][1,2];
        string bottomRight = cube[green][2,2];
        cube[green][0,2] = cube[yellow][0,2];
        cube[green][1,2] = cube[yellow][1,2];
        cube[green][2,2] = cube[yellow][2,2];
        cube[yellow][0,2] = cube[blue][2,0];
        cube[yellow][1,2] = cube[blue][1,0];
        cube[yellow][2,2] = cube[blue][0,0];
        cube[blue][0,0] = cube[white][2,2];
        cube[blue][1,0] = cube[white][1,2];
        cube[blue][2,0] = cube[white][0,2];
        cube[white][0,2] = topRight;
        cube[white][1,2] = centerRight;
        cube[white][2,2] = bottomRight;
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

