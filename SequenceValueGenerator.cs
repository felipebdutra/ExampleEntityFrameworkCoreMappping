using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace ConsoleApp1.EntityFrameworkCoreExample
{
    internal class SequenceValueGenerator : ValueGenerator<int>
    {
        private string v1;
        private string v2;

        public SequenceValueGenerator(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public override bool GeneratesTemporaryValues => false;

        public override int Next(EntityEntry entry)
        {
            using(var command = entry.Context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"SELECT {v1}.{v2}.NEXTVAL FROM DUAL";
                entry.Context.Database.OpenConnection();
                using(var READER = command.ExecuteReader())
                {
                    READER.Read();
                    return READER.GetInt32(0);
                }
            }
        }
    }
}