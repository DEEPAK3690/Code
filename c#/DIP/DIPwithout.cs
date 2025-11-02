using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP
{

    // Low-level module: Database Repository
    public class DatabaseRepositorys
    {
        public string GetData()
        {
            return "Data from database";
        }
    }

    // High-level module directly depends on DatabaseRepository
    public class DataProcessors
    {
        private readonly DatabaseRepositorys _repository;

        public DataProcessors()
        {
            _repository = new DatabaseRepositorys(); // Tight coupling!
        }

        public void ProcessData()
        {
            string data = _repository.GetData();
            Console.WriteLine("Processing: " + data);
        }
    }

    // Client Code
    class Programs
    {
        static void Main()
        {
            DataProcessors processor = new DataProcessors();
            processor.ProcessData();
        }
    }

}
