using System;
using SOLID.IntSeg.Interfaces;

namespace SOLID.IntSeg.Decorators
{
    /// <summary>
    /// Specific implementation of the DeleteWithConfirm decorator
    /// </summary>
    public class DeleteWithConfirmImpl<T> : DeleteWithConfirm<T>
    {
        public DeleteWithConfirmImpl(IDelete<T> deleteImpl) : base(deleteImpl)
        {
        }

        protected override bool ConfirmDelete(int key)
        {
            Console.WriteLine($"Are you sure you want to delete object with key = {key} ?");
            Console.Write("(type y for Yes, or n for No -> ");
            string answer = Console.ReadLine();
            Console.WriteLine();
            return answer == "y";
        }
    }
}