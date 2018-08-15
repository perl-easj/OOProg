using System;

namespace NoteBook
{
    public class TitleExistsException : Exception
    {
        public TitleExistsException(string message)
            : base(message)
        {
        }
    }
}