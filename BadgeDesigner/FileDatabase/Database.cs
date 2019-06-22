using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FileDatabase
{
    public static class Database
    {
        public static string FileName = "file.tbb";
        private static List<DatabaseItem> _objects;

        private static List<DatabaseItem> Objects
        {
            get
            {
                if (_objects == null)
                {
                    LoadDatabase();
                }
                return _objects;
            }
        }

        private static void SaveDatabase()
        {
            var everything = JsonConvert.SerializeObject(Objects);
            File.WriteAllText(FileName, everything);
        }

        private static void LoadDatabase()
        {
            try
            {
                var serialized = File.ReadAllText(FileName);
                var database = JsonConvert.DeserializeObject<List<DatabaseItem>>(serialized);
                _objects = database;
            }
            catch (Exception ex)
            {
                var x = 0;
            }
        }

        public static void AddOrUpdateDatabaseItem(string itemName, object data)
        {
            var item = new DatabaseItem()
            {
                Data = data,
                ItemName = itemName
            };

            var existing = Objects.FirstOrDefault(i => i.ItemName == item.ItemName);
            if (existing != null)
            {
                var index = Objects.IndexOf(existing);
                Objects.Remove(existing);
                Objects.Insert(index, item);
            }
            else
            {
                Objects.Add(item);
            }

            SaveDatabase();
        }

        public static object GetDatabaseItem(string itemName)
        {
            return Objects.FirstOrDefault(i => i.ItemName == itemName)?.Data;
        }
        private class DatabaseItem
        {
            public object Data { get; set; }
            public string ItemName { get; set; }
        }
    }
}
