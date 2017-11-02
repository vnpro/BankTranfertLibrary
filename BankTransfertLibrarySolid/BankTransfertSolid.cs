using System;
using System.IO;
using System.Text;

namespace BankTransfertLibrarySolid
{
    public enum LogType
    {
        File,
        Console,
    }

    interface IBankTransfertSolid
    {
        bool Transfert(uint transactionId, decimal amount, string fromBankIban, string toBankIban);
    }

    public class BankTransfertSolid : IBankTransfertSolid
    {
        private LogType logType = LogType.Console;
        private Logger log;

        public bool Transfert(uint transactionId, decimal amount, string fromBankIban, string toBankIban)
        {
            switch (logType)
            {
                case LogType.File:
                    log = new FileLogger();
                    break;
                case LogType.Console:
                    log = new ConsoleLogger();
                    break;
                default:
                    log = new ConsoleLogger();
                    break;
            }

            if (string.IsNullOrEmpty(fromBankIban) || string.IsNullOrEmpty(toBankIban))
            {
                log.Log(Severity.Error, "Both IBAN should have a value");
                throw new ArgumentNullException();
            }

            var hasTransfered = EmulateTransfert(amount, fromBankIban, toBankIban);

            if (!hasTransfered)
            {
                log.Log(Severity.Error, "Transfert interrupted");
                throw new InvalidOperationException();
            }

            FileWriter fw = new CsvWriter($"transaction_{DateTime.Now.ToString("dd_MM_yy")}.csv");
            fw.Write($"{transactionId};{amount};{fromBankIban};{toBankIban}");
            
            return true;
        }

        private bool EmulateTransfert(decimal amount, string fromBankIban, string toBankIban)
        {
            System.Threading.Thread.Sleep((int)TimeSpan.FromSeconds(4).TotalMilliseconds);

            return true;
        }
    }
}
