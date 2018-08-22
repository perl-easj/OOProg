using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using AddOns.Images.Implementation;
using AddOns.Images.Interfaces;
using Extensions.AddOns.Implementation;
using CarRetailDemo.ViewModels.App;
using CarRetailDemo.Views.App;

namespace CarRetailDemo.Configuration.App
{
    public class AppConfig
    {
        public static void Setup(Page mainPage, Frame appFrame)
        {
            SetupAppImages("..\\..\\..\\Assets\\App\\");
            SetupDomainImages("..\\..\\..\\Assets\\Images\\");

            appFrame.Navigate(typeof(FileView));
            ((AppViewModel)mainPage.DataContext).SetAppFrame(appFrame);
        }

        private static void SetupAppImages(string prefix)
        {
            ServiceProvider.Images.SetAppImageSource(AppImageType.NotFound, prefix + "NotSet.jpg");
            ServiceProvider.Images.SetAppImageSource(AppImageType.Logo, prefix + "Logo120x60.jpg");
        }

        private static void SetupDomainImages(string prefix)
        {
            List<IImage> imageList = new List<IImage>();

            #region Car image objects
            TaggedImage c1 = new TaggedImage("Red Sedan", prefix + "CarRedSedan.jpg");
            c1.AddTag("Car");
            c1.AddTag("Red");
            c1.AddTag("Sedan");
            c1.AddTag("Individual");

            TaggedImage c2 = new TaggedImage("Blue Combi", prefix + "CarBlueCombi.jpg");
            c2.AddTag("Car");
            c2.AddTag("Blue");
            c2.AddTag("Combi");
            c2.AddTag("Family");

            TaggedImage c3 = new TaggedImage("White Mini", prefix + "CarWhiteMini.jpg");
            c3.AddTag("Car");
            c3.AddTag("White");
            c3.AddTag("Mini");
            c3.AddTag("Family");

            TaggedImage c4 = new TaggedImage("Green Combi", prefix + "CarGreenCombi.jpg");
            c4.AddTag("Car");
            c4.AddTag("Green");
            c4.AddTag("Combi");
            c4.AddTag("Family");

            TaggedImage c5 = new TaggedImage("Purple Sport", prefix + "CarPurpleSport.jpg");
            c5.AddTag("Car");
            c5.AddTag("Purple");
            c5.AddTag("Sport");
            c5.AddTag("Family");

            TaggedImage c6 = new TaggedImage("Yellow Sport", prefix + "CarYellowSport.jpg");
            c6.AddTag("Car");
            c6.AddTag("Yellow");
            c6.AddTag("Sport");
            c6.AddTag("Individual");

            TaggedImage c7 = new TaggedImage("Black Sedan", prefix + "CarBlackSedan.jpg");
            c7.AddTag("Car");
            c7.AddTag("Black");
            c7.AddTag("Sedan");
            c7.AddTag("Family");

            TaggedImage c8 = new TaggedImage("Light Blue Combi", prefix + "CarLightBlueCombi.jpg");
            c8.AddTag("Car");
            c8.AddTag("Light Blue");
            c8.AddTag("Combi");
            c8.AddTag("Family");

            TaggedImage c9 = new TaggedImage("Magenta Pickup", prefix + "CarMagentaPickup.jpg");
            c9.AddTag("Car");
            c9.AddTag("Magenta");
            c9.AddTag("Pickup");
            c9.AddTag("Individual");

            imageList.Add(c1);
            imageList.Add(c2);
            imageList.Add(c3);
            imageList.Add(c4);
            imageList.Add(c5);
            imageList.Add(c6);
            imageList.Add(c7);
            imageList.Add(c8);
            imageList.Add(c9);
            #endregion

            #region Employee image objects
            TaggedImage s1 = new TaggedImage("Ann", prefix + "Ann.jpg");
            s1.AddTag("Employee");
            s1.AddTag("Female");

            TaggedImage s2 = new TaggedImage("Benny", prefix + "Benny.jpg");
            s2.AddTag("Employee");
            s2.AddTag("Male");

            TaggedImage s3 = new TaggedImage("Carol", prefix + "Carol.jpg");
            s3.AddTag("Employee");
            s3.AddTag("Female");

            TaggedImage s4 = new TaggedImage("Dan", prefix + "Dan.jpg");
            s4.AddTag("Employee");
            s4.AddTag("Male");

            TaggedImage s5 = new TaggedImage("Eliza", prefix + "Eliza.jpg");
            s5.AddTag("Employee");
            s5.AddTag("Female");

            imageList.Add(s1);
            imageList.Add(s2);
            imageList.Add(s3);
            imageList.Add(s4);
            imageList.Add(s5);
            #endregion

            #region Customer image objects
            TaggedImage cu1 = new TaggedImage("Allan", prefix + "Allan.png");
            cu1.AddTag("Customer");
            cu1.AddTag("Male");

            TaggedImage cu2 = new TaggedImage("Betty", prefix + "Betty.png");
            cu2.AddTag("Customer");
            cu2.AddTag("Female");

            TaggedImage cu3 = new TaggedImage("Carl", prefix + "Carl.png");
            cu3.AddTag("Customer");
            cu3.AddTag("Male");

            TaggedImage cu4 = new TaggedImage("Denice", prefix + "Denice.png");
            cu4.AddTag("Customer");
            cu4.AddTag("Female");

            TaggedImage cu5 = new TaggedImage("Eric", prefix + "Eric.png");
            cu5.AddTag("Customer");
            cu5.AddTag("Male");

            TaggedImage cu6 = new TaggedImage("Fiona", prefix + "Fiona.png");
            cu6.AddTag("Customer");
            cu6.AddTag("Female");

            imageList.Add(cu1);
            imageList.Add(cu2);
            imageList.Add(cu3);
            imageList.Add(cu4);
            imageList.Add(cu5);
            imageList.Add(cu6);
            #endregion

            ServiceProvider.Images.SetImages(imageList);
        }
    }
}