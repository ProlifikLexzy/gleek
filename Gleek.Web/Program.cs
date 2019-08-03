using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Gleek.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }

    public class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
    }

    public interface IStorable
    {
        void Write();
        void Read();
    }

    public class DocumentProcessor
    {
        private readonly IStorable disk;

        public DocumentProcessor(IStorable disk)
        {
            this.disk = disk;
        }

        public void Save()
        {
            disk.Write();
        }

        public void Open()
        {
            disk.Read();

        }
    }
    public class CloudDrive: IStorable
    {
        public void Write()
        {
            Console.WriteLine("Writing to cloud");
        }

        public void Read()
        {
            Console.WriteLine("Reading from cloud");
        }
    }

    public class HardDisk: IStorable
    {
        public void Write()
        {
            Console.WriteLine("Writing to hard disk");
        }

        public void Read()
        {
            Console.WriteLine("Reading from hard disk");
        }
    }

}
