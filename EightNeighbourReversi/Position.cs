using System;

namespace EightNeighbourReversi
{
   public class Position 
   {
       private int row;
       private int column;
       //Paramterized constructor set the value of  the fields
       public Position(int row, int column)
       {
           this.row = row;
           this.column = column;
       }

        //Getters methods for the fields
       public int getRow() 
       {
           return this.row;
       }

       public int getColumn() 
       {
           return this.column;
       }
   } 
}