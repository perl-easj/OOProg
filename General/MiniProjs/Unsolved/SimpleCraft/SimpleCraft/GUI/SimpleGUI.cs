using System;

namespace SimpleCraft.GUI
{
    public class SimpleGUI
    {
        #region Constants
        public const int LineTime = 0;
        public const int LineUserInput = 1;
        public const int LineSpellCast = 2;

        private const int LineOffset = 0;
        private const int LineFactor = 6;
        #endregion

        #region Static methods (set cursor position)
        public static void SetCursorPosition(int index, int characterIndex = 0, int left = 0)
        {
            Console.SetCursorPosition(left, characterIndex * LineFactor + LineOffset + index);
        }

        public static void SetCursorForTime()
        {
            SetCursorPosition(LineTime);
        }

        public static void SetCursorForUserInput(int left = 0)
        {
            SetCursorPosition(LineUserInput, 0, left);
        }

        public static void SetCursorForSpellCast(int offset = 0)
        {
            SetCursorPosition(LineSpellCast + offset);
        }
        #endregion

        #region Static methods (delete/reset)
        public static void DeleteLine(int index, int characterIndex)
        {
            DeleteLine(characterIndex * LineFactor + LineOffset + index);
        }

        public static void DeleteLine(int index)
        {
            SetCursorPosition(index, 0);
            Console.WriteLine("                                                                                    ");
        }

        public static void ResetUserInput()
        {
            SimpleGUI.DeleteLine(SimpleGUI.LineUserInput);
            SetCursorForUserInput();
        } 
        #endregion
    }
}