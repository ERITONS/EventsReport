using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var svc = new Service();
            var task = Task.Run(() => svc.Run());
            Task.WaitAll(new Task[] { task });

        }

        public class Service
        {

            public void Run()
            {
                var engine = new RuleEngine();
                var CincoMinutosEmMileSegundos = 300000;

                while (true)
                {
                    engine.Execute();
                    Console.WriteLine(DateTime.Now);
                    Thread.Sleep(CincoMinutosEmMileSegundos);
                }
            }
        }

        public class RuleEngine : IRuleEnginer
        {
            public void Execute()
            {
                var connString = "";
                var query = "";
            
                using (SqlConnection conn = new SqlConnection(connString)) {
                    
                    var cmd = new SqlCommand(query, conn);
                    var reader = cmd.ExecuteReader();
                    var eventos = new List<string>();

                    while (reader.Read())
                    {
                        eventos.Add(reader[0].ToString());
                    }

                    File.WriteAllLines($@"", eventos.ToArray());
                }

                Console.WriteLine("Teste conexão com o banco");
            }
        }

        public interface IRuleEnginer
        {
            void Execute();
        }
    }


}
