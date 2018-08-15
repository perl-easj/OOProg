namespace DrawShapes
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            // SHAPE A (10 stars in a single row)
            //
            // **********
            //
            for (int column = 0; column < 10; column++)
            {
                DrawingTool.DrawOneStar();
            }

            DrawingTool.StartNewLine();
            DrawingTool.StartNewLine();

            // SHAPE B (5 stars in a single row, separated by spaces)
            //
            // * * * * * 
            //
            for (int column = 0; column < 5; column++)
            {
                DrawingTool.DrawOneStar();
                DrawingTool.DrawOneSpace();
            }

            DrawingTool.StartNewLine();
            DrawingTool.StartNewLine();

            // SHAPE C  (10 rows of 10 stars each)
            //
            // **********
            // **********
            // **********
            // **********
            // **********
            // **********
            // **********
            // **********
            // **********
            // **********
            //
            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column < 10; column++)
                {
                    DrawingTool.DrawOneStar();
                }

                DrawingTool.StartNewLine();
            }

            DrawingTool.StartNewLine();

            // SHAPE D (a triangle, I guess...)
            //
            // *
            // **
            // ***
            // ****
            // *****
            // ******
            // *******
            // ********
            // *********
            // **********
            //
            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column <= row; column++)
                {
                    DrawingTool.DrawOneStar();
                }

                DrawingTool.StartNewLine();
            }

            DrawingTool.StartNewLine();

            // SHAPE E (X)
            //
            // *        *
            //  *      * 
            //   *    *   
            //    *  *    
            //     **     
            //     **     
            //    *  *    
            //   *    *   
            //  *      * 
            // *        *
            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column < 10; column++)
                {
                    if ((row == column) || ((row + column) == 9))
                    {
                        DrawingTool.DrawOneStar();
                    }
                    else
                    {
                        DrawingTool.DrawOneSpace();
                    }
                }

                DrawingTool.StartNewLine();
            }

            // The LAST line of code should be ABOVE this line
        }
    }
}