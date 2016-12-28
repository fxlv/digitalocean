using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalOcean.API;
using System.IO;


    class Program
    {
        static void Main(string[] args)
        {
            getAllDroplets();
            Console.ReadKey();

        }
        static async void getAllDroplets()
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string apiKeyPath = string.Format("{0}\\do_api.key", documentsPath);
            Console.WriteLine(apiKeyPath);
            string apiKey = "";
            try {
                apiKey = System.IO.File.ReadAllText(apiKeyPath);
            }
            catch (System.IO.FileNotFoundException){
                Console.WriteLine("Could not find the API key file.");
                Console.WriteLine(string.Format("Please make sure it is present in: {0}", apiKeyPath));
                Environment.Exit(1);
            }
            var client = new DigitalOceanClient(apiKey);
            Console.WriteLine("Getting all droplets...");
            var droplets = await client.Droplets.GetAll();
            Console.WriteLine();
            Console.WriteLine("Droplet name\t\t\tStatus\tMemory\tRegion");
            Console.WriteLine("_".PadRight(80,'_'));

            for (int i = 0; i < droplets.Count(); i++)
            {
                
                var droplet = droplets[i];
                string msg;
                string kernelName;
                string dropletName;
                dropletName = droplet.Name.PadRight(20,' ');
                string dropletStatus = droplet.Status;
                string dropletRegion = droplet.Region.Name;
                string dropletMemory = droplet.Memory.ToString();

                try
                {
                    kernelName = droplet.Kernel.Name;
                }
                catch (System.NullReferenceException)
                {
                    kernelName = "Unknown";
                }
                msg = String.Format("{0}\t\t{1}\t{2}\t{3}", dropletName, dropletStatus, dropletMemory, dropletRegion);

                Console.WriteLine(msg);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");


        }
    }

