using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankTransfertLibrarySolid
{
    interface IFileWriter
    {
        void Write(string message);
    }

    class FileWriter : IFileWriter
    {
        public string FileTitle { get; set; }

        public FileWriter(string fileTitle)
        {
            this.FileTitle = fileTitle;
        }

        public virtual void Write(string message)
        {
        }
    }

    class CsvWriter : FileWriter
    {
        public CsvWriter(string fileTitle) : base(fileTitle)
        {
        }

        public override void Write(string message)
        {
            //write csv
            var csv = new StringBuilder();
            // chemin : BankTranfertLibrary\BankTransfertLibraryTest\bin\Debug\netcoreapp2.0

            if (!File.Exists(FileTitle))
            {
                using (StreamWriter sw = File.CreateText(FileTitle))
                {
                    sw.WriteLine("Transaction;Amount;From;To");
                }
            }
            
            using (StreamWriter sw = File.AppendText(FileTitle))
            {
                sw.WriteLine(message);
            }
        }
    }
}
