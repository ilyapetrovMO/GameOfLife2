using System;

namespace GameofLife_2
{
    class Point
    {
        static int size_X=20;
        static int size_Y=20;
        
        static bool[,] Evo1=new bool[20,20];
        static bool[,] Evo2=new bool [20,20];
        
        public static void DrawLife()
        {
            FillRandomArray();

            int n=0;
            while (n<30)
            {
            CheckSetCase();

            for (int i = 0; i < size_Y-1 ; i++){
                for (int j = 0; j < size_X-1; j++)
                {
                    if(Evo1[j,i]){
                       System.Console.Write(" # ");
                    }
                    else {System.Console.Write("   ");}
                    if (j==size_X-2){System.Console.WriteLine( );}

                }
            }
            Console.Clear();
            n++;
            }
            Console.Read();
        }            
        
        private static void FillEmptyArray()
        {
            for (int i=0;i<size_Y-1;i++){
                for (int j = 0; j < size_X-1; j++)
                {
                    Evo1[j,i]=false;
                }
            }
        }

        private static void FillRandomArray()
        {
            Random random=new Random();
            for (int i=0;i<size_Y-1;i++)
            {
                for (int j = 0; j < size_X-1; j++)
                {
                    Evo1[j,i]=Convert.ToBoolean(random.Next(0,2));
                }
            }
        }

        private static bool CheckState(int Case, int X, int Y)
        {
            int counter=0;
            bool state=false;
            switch (Case)
            {
                case 0://x=0 y=0
                    if (Evo1[X+1,Y]){counter++;}
                    if (Evo1[X+1,Y+1]){counter++;}
                    if (Evo1[X,Y+1]){counter++;}
                    if (counter>2)state=true;else state=false;break;

                case 1://x>0 && x<size_X y=0
                    if (Evo1[X-1,Y]){counter++;}
                    if (Evo1[X-1,Y+1]){counter++;}
                    if (Evo1[X,Y+1]){counter++;}
                    if (Evo1[X+1,Y+1]){counter++;}
                    if (Evo1[X+1,Y]){counter++;}
                    if (counter>2)state=true;else state=false;break;

                case 2://x=size_X y=0
                    if (Evo1[X-1,Y]){counter++;}
                    if (Evo1[X-1,Y+1]){counter++;}
                    if (Evo1[X,Y+1]){counter++;}
                    if (counter>2)state=true;else state=false;break;

                case 3://x=0 y>0 && y<size_Y
                    if (Evo1[X,Y-1]){counter++;}
                    if (Evo1[X+1,Y-1]){counter++;}
                    if (Evo1[X+1,Y]){counter++;}
                    if (Evo1[X+1,Y+1]){counter++;}
                    if (Evo1[X,Y+1]){counter++;}
                    if (counter>2)state=true;else state=false;break;

                case 4://x=size_X y>0 && y<size_Y
                    if (Evo1[X,Y-1]){counter++;}
                    if (Evo1[X-1,Y-1]){counter++;}
                    if (Evo1[X-1,Y]){counter++;}
                    if (Evo1[X-1,Y+1]){counter++;}
                    if (Evo1[X,Y+1]){counter++;}
                    if (counter>2)state=true;else state=false;break;

                case 5://x=0 y=size_Y
                    if (Evo1[X,Y-1]){counter++;}
                    if (Evo1[X+1,Y-1]){counter++;}
                    if (Evo1[X+1,Y]){counter++;}
                    if (counter>2)state=true;else state=false;break;

                case 6://x>0 && x<size_X y=size_Y
                    if (Evo1[X-1,Y]){counter++;}
                    if (Evo1[X-1,Y-1]){counter++;}
                    if (Evo1[X,Y-1]){counter++;}
                    if (Evo1[X+1,Y-1]){counter++;}
                    if (Evo1[X+1,Y]){counter++;}
                    if (counter>2)state=true;else state=false;break;

                case 7://x=size_X y=size_Y
                    if (Evo1[X,Y-1]){counter++;}
                    if (Evo1[X-1,Y-1]){counter++;}
                    if (Evo1[X-1,Y]){counter++;}
                    if (counter>2)state=true;else state=false;break;

                case 8:
                    if (Evo1[X,Y-1]){counter++;}
                    if (Evo1[X+1,Y-1]){counter++;}
                    if (Evo1[X+1,Y]){counter++;}
                    if (Evo1[X+1,Y+1]){counter++;}
                    if (Evo1[X,Y+1]){counter++;}
                    if (Evo1[X-1,Y+1]){counter++;}
                    if (Evo1[X-1,Y]){counter++;}
                    if (Evo1[X-1,Y-1]){counter++;}
                    if (counter>2)state=true;else state=false;break;

            }
            return state;
        }
        private static void CheckSetCase()
        {
            for (int i = 0; i < size_Y-1; i++)
            {
                for (int j = 0; j < size_X-1; j++)
                {
                    
                    if (j==0 && i==0){Evo2[j,i]=CheckState(0,j,i);}
                    else if (j>0 && j<size_X && i==0){Evo2[j,i]=CheckState(1,j,i);}
                    else if (j==size_X && i==size_Y){Evo2[j,i]=CheckState(2,j,i);}
                    else if (j==0 && i>0 && i<size_Y){Evo2[j,i]=CheckState(3,j,i);}
                    else if (j==size_X && i>0 && i<size_Y){Evo2[j,i]=CheckState(4,j,i);}
                    else if (j==0 && i==size_Y){Evo2[j,i]=CheckState(5,j,i);}
                    else if (j>0 && j<size_X && i==size_Y){Evo2[j,i]=CheckState(6,j,i);}
                    else if (j==size_X && i==size_Y){Evo2[j,i]=CheckState(7,j,i);}
                    else Evo2[j,i]=CheckState(8,j,i);

                }
            }
            Evo1=Evo2;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Point.DrawLife();
        }
    }
}
