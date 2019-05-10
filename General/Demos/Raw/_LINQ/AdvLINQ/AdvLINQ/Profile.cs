using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvLINQ
{
    public class Profile
    {
        public Profile(string userName, int imageId)
        {
            UserName = userName;
            ImageData = ImageDB.Read(imageId);
        }

        public string UserName { get;}
        public int[] ImageData { get; } // Raw image data

        public void Display()
        {
            // Uses UserName and ImageData
        }
    }
}
