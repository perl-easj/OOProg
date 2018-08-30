using System;

namespace RepetitionExercises
{
    public class HomeTheaterTest
    {
        // Kørsel af testen skal give dette output:
        //
        // Current status of Home Theater
        // ------------------------------
        // Smart TV       : Off, showing channel (No channel)
        // Blu-Ray player : Off, is Stopped
        // Left Speaker   : Off, is at volume 0
        // Right Speaker  : Off, is at volume 0

        // Current status of Home Theater
        // ------------------------------
        // Smart TV       : On, showing channel 1
        // Blu-Ray player : On, is Stopped
        // Left Speaker   : On, is at volume 0
        // Right Speaker  : On, is at volume 0

        // Current status of Home Theater
        // ------------------------------
        // Smart TV       : On, showing channel 4
        // Blu-Ray player : On, is Playing
        // Left Speaker   : On, is at volume 40
        // Right Speaker  : On, is at volume 40

        public static void Run()
        {
            HomeTheater ht = new HomeTheater();
            Console.WriteLine(ht);

            ht.ToggleOnOff();
            Console.WriteLine(ht);

            ht.IncreaseChannel();
            ht.IncreaseChannel();
            ht.IncreaseChannel();
            ht.PlayDevice();
            for (int i = 0; i < 40; i++)
            {
                ht.IncreaseVolume();
            }

            Console.WriteLine(ht);
        }
    }
}